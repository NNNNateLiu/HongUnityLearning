using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCollision : MonoBehaviour
{
    public string tag;
    /*
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("stop overlapping something");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("start overlapping something");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("overlapping something");
    }
    */

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Block")
        {
            Debug.Log("hit block");
        }
        else
        {
            Debug.Log("hit something strange");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        //Debug.Log("stop hit something");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("keep hitting something");
    }
}
