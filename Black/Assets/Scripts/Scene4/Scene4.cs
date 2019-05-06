using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scene4 : MonoBehaviour {

    public GameObject mask;
    public float radius = 600;//球离中心点的距离
    public static Scene4 Instance;
    public Transform ballParent;
    private System.Random random = new System.Random();
    public float speed = 2;//小球的移动速度
    public float ballHideTime = 2;//小球隐藏的时间
    public float ballShowTime = 2;//小球出现的时间
    public float maskTime = 3;//遮罩停留的时间
    public float ballMoveTime = 3;//小球在白圈内移动的时间
    public Vector3 maskScale = new Vector3(0.63f,0.63f,0.63f);//遮罩收缩到几倍时停止收缩
    public float maskScaleTime = 5;//遮罩缩放的时间
    public float ballMoveDrua = 0.01f;//小球震动一次的时间
    public float ballMoveDistance = 5;//小球震动的幅度

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
       for(int i = 0; i < ballParent.childCount; i++)
        {
            ballParent.GetChild(i).GetComponent<BallAction>().num = random.Next(0,8);
        }
        StartCoroutine(MaskScale());
    }
    IEnumerator MaskScale()
    {
        yield return new WaitForSeconds(maskTime);
        while (true)
        {
            mask.transform.DOScale(maskScale,maskScaleTime);
            yield return new WaitForSeconds(maskScaleTime+ballMoveTime);
            for (int i = 0; i < ballParent.childCount; i++)
            {
                ballParent.GetChild(i).GetComponent<BallAction>().Hide(); 
            }
            yield return new WaitForSeconds(maskTime);
            mask.transform.DOScale(Vector3.one,maskScaleTime);
            yield return new WaitForSeconds(maskScaleTime);
            for (int i = 0; i < ballParent.childCount; i++)
            {
                ballParent.GetChild(i).GetComponent<BallAction>().ResetPos();
                ballParent.GetChild(i).GetComponent<BallAction>().Show();
            }
            yield return new WaitForSeconds(maskTime);
        }
    }


}

