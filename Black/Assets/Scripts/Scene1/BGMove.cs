using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour {

    public float moveSpeed;

    private Vector3 move = new Vector3(0,1f,0);
    private Vector3 DownPos = new Vector3(0,-Screen.height,0);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition += moveSpeed * move;
        if(transform.localPosition.y >= Screen.height)
        {
            transform.localPosition = DownPos;
        }
	}
}
