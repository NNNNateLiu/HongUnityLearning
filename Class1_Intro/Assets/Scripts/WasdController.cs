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

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = playerStartPoint.position;
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
        }
    }

    //player life system
    public void Life()
    {
        life--;
        if (life == 3)
        {
            Life_1.SetActive(true);
            Life_2.SetActive(true);
            Life_3.SetActive(true);
            Debug.Log("life=3");
        }

        if (life == 2)
        {
            Life_1.SetActive(true);
            Life_2.SetActive(true);
            Life_3.SetActive(false);
            Debug.Log("life=2");
        }

        if (life == 1)
        {
            Life_1.SetActive(true);
            Life_2.SetActive(false);
            Life_3.SetActive(false);
            Debug.Log("life=1");
        }

        if (life < 1)
        {
            Life_1.SetActive(false);
            Life_2.SetActive(false);
            Life_3.SetActive(false);
            Debug.Log("dead");
            Destroy(gameObject);
        }
    }


    //Homework3
    //1，把碰撞检测，写在'Stone'上面，当stone检测到玩家，把玩家坐标设置为玩家起点坐标
    //2，使用TriggerBox做碰撞检测，而不是Collision
    //（选作）3，使用TriggerBox，当火箭运动到屏幕上边缘时，回到起点
    //（选作）4，给玩家添加'生命值'变量，玩家有三点生命值，每碰到一次stone扣一点，扣没，游戏结束（销毁玩家）

}