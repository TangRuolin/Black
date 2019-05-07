using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Star : MonoBehaviour {

    public float speed = 0.1f;
    public Transform earth1;
    public Transform earth;
    [HideInInspector]
    public bool move = false;
    private Vector3 oldpos;
    private Transform santi;
    private float time;
	// Use this for initialization
	void Start () {
        //transform.LookAt(Earth);
        oldpos = transform.position;
        santi = transform.Find("oldPos");
        time = Earth.Instance.time;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //if (Vector3.Distance(transform.position, earth.position) <= 1)
        //{
        //    move = false;
        //    transform.SetParent(earth);
        //}

        if (move)
        {
            float dis = Vector3.Distance(transform.position, earth1.position) - 1f;
            if ( dis <speed)
            {
                transform.position = Vector3.MoveTowards(transform.position, earth1.position, dis);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, earth1.position, speed);
            }
          //  Debug.Log(Vector3.Distance(transform.position, earth1.position));
            

        }
        // transform.Translate(transform.forward*speed);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "Earth")
        {
            move = false;
            transform.SetParent(earth);
            Earth.Instance.num++;
        }
    }
   
    //IEnumerator SetPos()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(time);
    //        transform.position = oldpos;
    //        transform.SetParent(santi);
    //        move = true;
    //    }
        
    //}
   
}
