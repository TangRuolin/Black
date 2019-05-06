using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scene4 : MonoBehaviour {

    public GameObject mask;
    public float radius = 600;
    public static Scene4 Instance;
    public Transform ballParent;
    public Vector3[] Position;
    private System.Random random = new System.Random();
    public float speed = 2;
    public float ballHideTime = 2;
    public float ballShowTime = 2;
    public float maskTime = 3;
    public float ballMoveTime = 3;
    public Vector3 maskScale = new Vector3(0.63f,0.63f,0.63f);
    public float maskScaleTime = 5;
    

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

