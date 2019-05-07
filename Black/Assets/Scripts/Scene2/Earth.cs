using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Earth : MonoBehaviour {

    public float time = 3;
    public static Earth Instance;
    public GameObject Santi;
    private List<Vector3> pos = new List<Vector3>();
    private Transform oldPos;
    [HideInInspector]
    public int num = 0;
    private bool canTouch = true;
    private List<SantiStar> starList = new List<SantiStar>();
    private System.Random random = new System.Random();
    private bool destory = false;
    private int pointNum = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        oldPos = GameObject.Find("oldPos").transform;
        for(int i = 0; i < oldPos.childCount; i++)
        {
            pos.Add(oldPos.GetChild(i).position);
        }
    }
    // Update is called once per frame
    void Update () {
        if (canTouch)
        {
            if (Input.GetMouseButtonDown(0))
            {
                pointNum++;
                Create();
            }
        }
        if(pointNum == 10)
        {
            canTouch = false;
        }
        if(num == 10)
        {
            StartCoroutine(SetPos());
            num = 0;
            pointNum = 0;

        }

    }
   private void Create()
    {
        SantiStar san = null;
        for(int i = 0; i < starList.Count; i++)
        {
            if (!starList[i].go.activeSelf)
            {
                san = starList[i];
            }
        }
        if (san == null)
        {
            san = new SantiStar(Santi);
            starList.Add(san);
        }
        san.SetData(pos[random.Next(0, pos.Count)]);
        san.ReStart();
    }
    private void Clear()
    {

    }
    IEnumerator SetPos()
    {

        for (int i = 0; i < starList.Count; i++)
        {
            starList[i].Destory(time);
        }
        yield return new WaitForSeconds(time+1);
        for (int i = 0; i < starList.Count; i++)
        {
            starList[i].go.SetActive(false);
            starList[i].go.transform.SetParent(oldPos);
        }
        canTouch = true;
    }
}

public class SantiStar
{
    public GameObject go;
    public SantiStar(GameObject model) {
        go = GameObject.Instantiate(model);
    }

    public void SetData(Vector3 pos)
    {
        go.transform.position = pos;
    }

    public void Destory(float time)
    {
        go.GetComponent<MeshRenderer>().material.DOFade(0,time);
    }
    public void ReStart()
    {
        go.GetComponent<MeshRenderer>().material.DOFade(1,0.01f);
        go.SetActive(true);
        go.GetComponent<Star>().move = true;
    }
}
