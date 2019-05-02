using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Scene1 : MonoBehaviour {


    public float druaTime;//雷达边消失时间
    public float intervalTime;//雷达边出现间隔时间
    public float colorTime ;//雷达颜色渐变时间
    public Transform leidaBack;
    public Transform leidaFront;
    private List<Image> back = new List<Image>();
    private List<Image> front = new List<Image>();
    private bool isEnd = true;

    public static Scene1 Instance;
    private bool isShow = false;
    private float time = 0;
    public GameObject santi;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {

		for(int i = 0; i < leidaBack.childCount; i++)
        {
            back.Add(leidaBack.GetChild(i).GetComponent<Image>());
            front.Add(leidaFront.GetChild(i).GetComponent<Image>());
        }
        StartCoroutine(Show());
    }
	
	// Update is called once per frame
	void Update () {
        //time += Time.deltaTime;
        //if(time > 10)
        //{
            
        //}
	}

    public void OnButtonDown()
    {
        isShow = true;
    }

    public void OnButtonUp()
    {
        isShow = false;
    }

    IEnumerator Show()
    {
        while (true)
        {
            if (isShow && IsEnd())
            {
                
                for (int i = 0; i < back.Count; i++)
                {
                    yield return new WaitForSeconds(intervalTime);
                    back[i].gameObject.SetActive(true);
                    back[i].DOFade(1,colorTime);
                    front[i].gameObject.SetActive(true);
                    front[i].DOFade(1, colorTime);
                    if(!santi.activeSelf && i == 7)
                    {
                        StartCoroutine(Santi());
                    }
                    if (!isShow)
                    {
                        break;
                    }
                }
               
            }
            yield return null;
            
        }
        
    }

    IEnumerator Santi()
    {
        yield return new WaitForSeconds(colorTime);
        santi.SetActive(true);
    }

    bool IsEnd()
    {
        for(int i = 0; i < back.Count; i++)
        {
            if (back[i].color.a == 1)
            {
                return false;
            }
        }
        return true;
    }
    

}
