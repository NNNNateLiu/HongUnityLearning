using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameObject bulletPrefab;
    public Transform bulletPoint;

    public float speed;
    public Vector2 Velocity;
    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
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
    }
}

/*
HW5: 
给Bullet编写脚本需涵盖一下功能：
1，当子弹被生成的时候，需要沿Y轴正方向运动（子弹带有初速度，用Rigidbody2D实现）
2，当子弹打中"敌人"（collider进行碰撞检测）的时候，销毁敌人和子弹
*/
