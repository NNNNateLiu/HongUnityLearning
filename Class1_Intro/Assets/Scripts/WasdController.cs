//Library 库文件

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public 公有; private 私有

//Frame 帧; Update 

public class WasdController : MonoBehaviour
{
    /*
    public int A;

    public int B;

    public int C;
    */
    
    public float Speed = 1.2f;
    public Transform playerStartPoint;
    public int life = 3;
    public GameObject Life_1, Life_2, Life_3;
    public int score = 0;
    
    public GameObject art;
    public UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //Nate: Compare ABC
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CompareABC(A, B, C);
        }
        else
        {
            //Debug.Log("No Input!");
        }
        */

        //Wasd Controller
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Moving Left");
            //Move Player to Left in Speed
            gameObject.transform.position = gameObject.transform.position + Vector3.left * Speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("Moving Right");
            //Player moves right in certain speed
            gameObject.transform.position = gameObject.transform.position + Vector3.right * Speed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("Moving Up");
            //Move Player to Up in Speed
            gameObject.transform.position = gameObject.transform.position + Vector3.up * Speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("Moving Down");
            //Player moves right in certain speed
            gameObject.transform.position = gameObject.transform.position + Vector3.down * Speed;
        }

    }
    /*
    public int CompareABC(int A, int B, int C)
    {
        int Max = 0;

        if (A > B)
        {
            //A > B 成立；A greater than B is True
            Max = A;

        }
        else
        {
            //A > B is false
            Max = B;
        }

        if (C > Max)
        {
            Max = C;
        }

        Debug.Log("Max is " + Max);
        return Max;
    }


    //player collision
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Stone")
        {
            gameObject.transform.position = playerStartPoint.position;
        }
    }
    */

    //player finish triggerbox
    private void OnTriggerEnter2D(Collider2D col)
    {
        //check if player reach the finish point
        if (col.gameObject.tag == "Finish")
        {
            Debug.Log("win!");
            //set player back to startpoint
            gameObject.transform.position = playerStartPoint.position;
            //player gain 1 score
            score ++;
            //Update txt_Score
            uiManager.UpdateScore(score);
        }
    }

    //player life system
    public void Life()
    {
        life--;
        if (life == 2)
        {
            uiManager.img_Life_3.color = Color.black;
            Debug.Log("life=2");
        }

        if (life == 1)
        {
            uiManager.img_Life_2.color = Color.black;
            Debug.Log("life=1");
        }

        if (life < 1)
        {
            uiManager.img_Life_1.color = Color.black;
            Debug.Log("dead");
            //update txt_Score to game over
            uiManager.txt_Score.text = "Game Over!";
            //activate restart button
            uiManager.but_Restart.SetActive(true);
            //make player 'art' disable
            art.SetActive(false);
        }
    }

    public void Initialization()
    {
        gameObject.transform.position = playerStartPoint.position;
        uiManager.UpdateScore(0);
        art.SetActive(true);
        uiManager.img_Life_1.color = Color.white;
        uiManager.img_Life_2.color = Color.white;
        uiManager.img_Life_3.color = Color.white;
        uiManager.but_Restart.SetActive(false);
        life = 3;
        score = 0;
    }
    
    //Homework4
    //结合前三节课所学（input、Collider&Trigger、UI）给Space Race做一个特性

}