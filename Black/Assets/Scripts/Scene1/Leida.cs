using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leida : MonoBehaviour {

    private float druaTime;
    private float time = 0;
    private float colorTime;
    // Use this for initialization
    private void Start()
    {
        druaTime = Scene1.Instance.druaTime;
        colorTime = Scene1.Instance.colorTime;
    }
    void OnEnable () {
        
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time > druaTime)
        {
            this.gameObject.SetActive(false);
        }
	}
}
