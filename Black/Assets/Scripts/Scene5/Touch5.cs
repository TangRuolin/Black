using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch5 : MonoBehaviour {

    public float factor = 1000f;
	// Use this for initialization
	void Start () {
		
	}
    private UnityEngine.Touch oldTouch1;  //上次触摸点1(手指1)
    private UnityEngine.Touch oldTouch2;  //上次触摸点2(手指2)
    bool move = false;
    Vector2 oldPosition;
    Vector2 newPosition;// Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            oldPosition = Input.mousePosition;
            move = true;

        }
        if (move)
        {
            newPosition = Input.mousePosition;
            float dis = Vector2.Distance(oldPosition, newPosition);
            float scaleFactor = dis / factor;
            if (scaleFactor > 0.005f)
            {
                scaleFactor = 0.005f;
            }
            if (transform.localScale.y <= 0.02f)
            {
                if (transform.localScale.x > 0)
                    transform.localScale -= new Vector3(scaleFactor, 0, 0);
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(0, 0, 0);
                }
            }
            else
            {
                transform.localScale -= new Vector3(0, scaleFactor, 0);

            }
            oldPosition = newPosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            move = false;
        }
#elif UNITY_IPHONE || UNITY_ANDROID

      
          if (Input.touchCount <= 0)
        {
            return;
        }
        //多点触摸, 放大缩小
        UnityEngine.Touch newTouch1 = Input.GetTouch(0);
        UnityEngine.Touch newTouch2 = Input.GetTouch(1);
        //第2点刚开始接触屏幕, 只记录，不做处理
        if (newTouch2.phase == TouchPhase.Began)
        {
            oldTouch2 = newTouch2;
            oldTouch1 = newTouch1;
            return;
        }
        //计算老的两点距离和新的两点间距离，变大要放大模型，变小要缩放模型
        float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
        float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);
        //两个距离之差，为正表示放大手势， 为负表示缩小手势
        float offset = newDistance - oldDistance;
        if(offset > 0)
        {
            offset = 0;
        }
        //放大因子， 一个像素按 0.01倍来算(100可调整)
        float scaleFactor = offset / factor;
         if(scaleFactor > 0.005f)
            {
                scaleFactor = 0.005f;
            }
          if (transform.localScale.y <= 0.01f)
            {
                if(transform.localScale.x >0)
                   transform.localScale += new Vector3(scaleFactor, 0, 0);
                if(transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(0, 0, 0);
                }
            }
            else
            {
                transform.localScale += new Vector3(0, scaleFactor, 0);

            }
        
        //记住最新的触摸点，下次使用
        oldTouch1 = newTouch1;
        oldTouch2 = newTouch2;
#endif
    }
}
