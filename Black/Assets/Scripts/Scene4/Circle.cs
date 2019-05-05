using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {

   

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        
    //}
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<BallAction>().Direction();
        }
    }
}
