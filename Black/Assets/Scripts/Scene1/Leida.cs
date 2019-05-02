using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Leida : MonoBehaviour {

    private float druaTime;
    private float time = 0;
    private float colorTime;
    private Image image;
    // Use this for initialization
    private void Start()
    {
        druaTime = Scene1.Instance.druaTime;
        colorTime = Scene1.Instance.colorTime;
        image = GetComponent<Image>();
    }
    void OnEnable () {
        
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time > druaTime)
        {
            image.DOFade(0, colorTime);
            StartCoroutine(DestorySelf());
        }
	}
    IEnumerator DestorySelf()
    {
        yield return new WaitForSeconds(colorTime);
        this.gameObject.SetActive(false);
    }
}
