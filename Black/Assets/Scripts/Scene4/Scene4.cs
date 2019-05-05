using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4 : MonoBehaviour {

    public GameObject mask;
    public float radius = 600;
    public static Scene4 Instance;
    public Transform ballParent;
    public Vector3[] Position;
    private System.Random random = new System.Random();
    public float speed = 2;
    public float maskSpeed = 1;
    public bool canMove = true;

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
        maskSpeed = maskSpeed * 0.0001f;
        StartCoroutine(MaskScale());
    }
    IEnumerator MaskScale()
    {
        while (canMove)
        {
            if(mask.transform.localScale.x < 0.63f)
            {
                canMove = false;
                break;
            }
            mask.transform.localScale -= new Vector3(maskSpeed, maskSpeed, maskSpeed);
            yield return null;
        }
    }


}

