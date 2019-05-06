using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class BallAction : MonoBehaviour ,IDragHandler{


    private RectTransform curRecTran;
    private float distance;
    public Transform circle;
    private float radius = 600;
    public Sprite BallAfter;
    public Sprite BallBefore;
    private bool change = true;
    private List<Vector3> direction = new List<Vector3>();
    System.Random random = new System.Random();
    Vector3 nowDirection;
    private Vector3[] dire;
    private float speed;
    public int num;
    private Vector3 oldPos;
    private float hideTime;
    private float showTime;
    private bool move = true;
    private float moveTime;
    private float moveDistance;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            nowDirection = -nowDirection;
        }
    }


    // Use this for initialization
    void Start () {
        Vector3 leftup = new Vector3(1,1,0);
        Vector3 rightUp = new Vector3(-1,1,0);
        dire = new Vector3[] { transform.up , -transform.up , transform.right ,-transform.right,leftup,-leftup,rightUp,-rightUp };
        radius = Scene4.Instance.radius;
        curRecTran = GetComponent<RectTransform>();
        speed = Scene4.Instance.speed;
        oldPos = transform.position;
        hideTime = Scene4.Instance.ballHideTime;
        showTime = Scene4.Instance.ballShowTime;
        moveTime = Scene4.Instance.ballMoveDrua;
        moveDistance = Scene4.Instance.ballMoveDistance;
        StartCoroutine(BallMove());
    }
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(transform.position,circle.position);
        if(distance <= radius)
        {
            if (change)
            {
                nowDirection = dire[num];
                GetComponent<Image>().sprite = BallAfter;
                change = false;
                move = false;
            }
            transform.Translate(nowDirection*speed);
        }
        if(distance > radius)
        {
            if (!change)
            {
                GetComponent<Image>().sprite = BallBefore;
                change = true;
                move = true;
            }
            
        }
	}
    /// <summary>
    /// 改变方向
    /// </summary>
    public void Direction()
    {
        direction.Clear();
        // float x,y;
        int x, y;
        if (transform.position.x > 1350)
        {
            //x = Random.Range(-1f, 0f);
            x = random.Next(-1,1);
        }
        else
        {
            // x = Random.Range(0f, 1f);
            x = random.Next(0,2);
        }
       if(transform.position.y > 1000)
        {
            // y = Random.Range(-1f, 0f);
            y = random.Next(-1,1);
            if (x == 0)
            {// y = Random.Range(-1f, -0.9f);
                y = -1;
            }
        }
        else
        {
            //y = Random.Range(0f, 1f );
            y = random.Next(0,2);
            if(x == 0)
            {
                // y = Random.Range(0.1f, 1f);
                y = 1;
            }
        }
        nowDirection = new Vector3(x,y,0);
       //while(nowDirection == newDire)
       //{
       //   newDire = direction[random.Next(0, 2)];
       //}
       // //oldDirection = nowDirection;
       // nowDirection = newDire;
    }

    /// <summary>
    /// 小球微震动
    /// </summary>
    IEnumerator BallMove()
    {
        while (true)
        {
            if (move)
            {
                transform.DOMoveY(transform.position.y + moveDistance, moveTime, true);
                yield return new WaitForSeconds(moveTime);
                transform.DOMoveY(transform.position.y - moveDistance, moveTime, true);
                yield return new WaitForSeconds(moveTime);
            }
            yield return null;
        }
      
    }


    /// <summary>
    /// 小球的拖动
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(curRecTran, eventData.position,

        eventData.pressEventCamera, out globalMousePos))

        {
            curRecTran.position = globalMousePos;
        }
       
    }

    public void ResetPos()
    {
        transform.position = oldPos;
    }

    public void Hide()
    {
        GetComponent<Image>().DOFade(0,hideTime);
    }

    public void Show()
    {
        GetComponent<Image>().DOFade(1,showTime);
    }

}
