using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameObject bulletPrefab;
    public Transform bulletPoint;

    public float speed ;
    public Vector2 Velocity;
    public float Timer;
    public float FireRate;
    private Animator animator;


    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Timer = FireRate;
    }

    
    private void Update()
    {
        Velocity = rb2d.velocity;
        if (Input.GetKey(KeyCode.D))
        {
            //add vector2.right * speed to the rb2d
            rb2d.AddForce(Vector2.right * speed);
            //rb2d.velocity = Vector2.right * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //add vector2.right * speed to the rb2d
            rb2d.AddForce(Vector2.left * speed);
            //rb2d.velocity = Vector2.left * speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            //add vector2.right * speed to the rb2d
            rb2d.AddForce(Vector2.up * speed);
            //rb2d.velocity = Vector2.right * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //add vector2.right * speed to the rb2d
            rb2d.AddForce(Vector2.down * speed);
            //rb2d.velocity = Vector2.left * speed;
        }

        //Space key is pressed, generate bullet&play animation: Fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Generate a bullet
            Instantiate(bulletPrefab, bulletPoint.position, Quaternion.identity);
            animator.SetBool("Is Firing", true);
        }
        //Continuous firing
        if (Input.GetKey(KeyCode.Space))
        {
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                Timer = FireRate;
                Instantiate(bulletPrefab, bulletPoint.position, Quaternion.identity);
            }
            //Generate bullets
        }

        //Space key is not pressed, keep animation: Idle
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Is Firing", false);
        }

        //move key is pressed, play animation: Move
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("Is Moving",true);
            //Debug.Log("开始移动");
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Is Moving", true);
            //Debug.Log("开始移动");
        }

        //move key is not pressed, keep animation: Idle
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) 
        {
            animator.SetBool("Is Moving",false);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Is Moving", false);
        }


    }
}

/*
HW6: 
给玩家创建动画状态机AnimatorController：
1，实现三种状态间来回切换（移动Moving,站立Idle,开火Fire）
2，选择一种动画方式制作动画片段 Animation Clip（帧动画or关键帧动画）
*/
