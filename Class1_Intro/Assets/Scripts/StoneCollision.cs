using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCollision : MonoBehaviour
{
    //public GameObject Rocket;
    //public string tag;
    //public bool isCollision;
    //public Transform playerStartPoint;
    //public int life = 3;


    void Start()
    {

    }


    /*public void DisableStone()
    {
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        collider.enabled = false;//禁用碰撞组件
        Debug.Log("陨石无效");
    }
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

        /*
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
        */

        //stone collision
        /*
        void OnCollisionEnter2D(Collision2D col)
        {
            //check if the stone hit player
            if (col.gameObject.tag == "Player")
            {
                //find player
                Debug.Log("hit player");
                Rocket = GameObject.FindWithTag("Player");
                //set player back to startpoint
                Rocket.transform.position = playerStartPoint.position;
            }
        }
        */


        /*
        //stone triggerbox
        private void OnTriggerEnter2D(Collider2D col)
        {
            //check if the stone hit player
            if (col.gameObject.tag == "Player")
            {       
                Debug.Log("hit player");
                //find player
                Rocket = GameObject.FindWithTag("Player");
                //set player back to startpoint
                Rocket.transform.position = playerStartPoint.position;
                //调用Life函数
                GameObject.Find("Rocket").GetComponent<WasdController>().Life();
            }
        }
        */
}