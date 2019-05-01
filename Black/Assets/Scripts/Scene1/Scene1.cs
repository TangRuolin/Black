using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : MonoBehaviour {


    public float druaTime = 1;//雷达边消失时间
    public float intervalTime;//雷达边出现间隔时间
    public float colorTime = 0.5f;//雷达颜色渐变时间
    public Transform leidaBack;
    public Transform leidaFront;
    private List<GameObject> back = new List<GameObject>();
    private List<GameObject> front = new List<GameObject>();
    private bool isEnd = true;

    private float time = 0;
    public static Scene1 Instance;
    private bool isShow = false;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
		for(int i = 0; i < leidaBack.childCount; i++)
        {
            back.Add(leidaBack.GetChild(i).gameObject);
            front.Add(leidaFront.GetChild(i).gameObject);
        }
        StartCoroutine(Show());
    }
	
	// Update is called once per frame
	void Update () {
      
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
                    back[i].SetActive(true);
                    front[i].SetActive(true);
                    if (!isShow)
                    {
                        break;
                    }
                }
               
            }
            yield return null;
            
        }
        
    }

    bool IsEnd()
    {
        for(int i = 0; i < back.Count; i++)
        {
            if (back[i].activeSelf)
            {
                return false;
            }
        }
        return true;
    }
    

}
