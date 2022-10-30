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

    private Animator animator;
    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Generate a bullet
            Instantiate(bulletPrefab, bulletPoint.position, Quaternion.identity);
        }
        
        //check if move key is pressed, then play animations
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("isWalking",true);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isWalking",false);
        }
    }
}

/*
HW6: 
给玩家创建动画状态机AnimatorController：
1，实现三种状态间来回切换（移动Moving,站立Idle,开火Fire）
2，选择一种动画方式制作动画片段 Animation Clip（帧动画or关键帧动画）
*/
