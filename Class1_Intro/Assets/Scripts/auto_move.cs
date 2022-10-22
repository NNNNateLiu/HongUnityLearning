using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.UI;

public class auto_move : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;
    private float Speed = 0.003f;
    public bool isLeftMovingStone = false;
    public float LowSpeedTime = 0f;
    public UIManager uiManager;
    public int amount = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (isLeftMovingStone == true)
        {
            //set right moving stone position to endpoint position at the start of the game
            gameObject.transform.position = EndPoint.position;
        }
        else
        {
            //set left moving stone position to startpoint position at the start of the game
            gameObject.transform.position = StartPoint.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //check if which direction this stone moves to
        if (isLeftMovingStone == true)
        {
            //this is a left moving stone
            if (gameObject.transform.position.x > StartPoint.position.x)
            {
                gameObject.transform.position = gameObject.transform.position + Vector3.left * Speed;
                if (gameObject.transform.position.x < StartPoint.position.x)
                {
                    gameObject.transform.position = EndPoint.position;
                }
            }
        }
        else
        {
            //this is a right moving stone
            if (gameObject.transform.position.x < EndPoint.position.x)
            {
                // keep moving the stone in Speed
                gameObject.transform.position = gameObject.transform.position + Vector3.right * Speed;
                //gameObject.transform.position += (Vector3.right * Speed);

                // check if stone is at the right of the endpoint, after each move
                if (gameObject.transform.position.x > EndPoint.position.x)
                {
                    //set stone position back to startpoint   
                    gameObject.transform.position = StartPoint.position;
                }
            }
        }



        //Lowspeed effect
        if (LowSpeedTime > 0)
            //触发减速效果
        {
            LowSpeedTime -= Time.deltaTime;
            Speed =0.005f;
            Debug.Log("LOWspeed");

        }
        else
        //效果结束
        {

            Speed =0.02f;
            Debug.Log("NormalSpeed");

        }


        //amount
        if(amount < 1 )
        {
            uiManager.but_Lowspeed.SetActive(false);
        }
    }


    public void Lowspeed()
    {
        Debug.Log("开始减速");
        LowSpeedTime = 4f;
        //效果持续时间
        if (LowSpeedTime < 0)
        {
            LowSpeedTime = 0f;
        }
        
        amount--;
        //Update txt_amount
        uiManager.UpdateSkill(amount);

    
      
        //uiManager.but_Lowspeed.SetActive(false);
        /*
         
        if (LowSpeedTime < 0)
        {
            LowSpeedTime = 5f;
            Speed = 0.01f;
            Debug.Log("LOWspeed");
        }
        */

    }


    public void SkillInitialization()
    {
    
        //skill
        uiManager.but_Lowspeed.SetActive(true);
       
        amount = 3;
    }
}


