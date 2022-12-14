using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public bool isEnemeyBullet = false;
    //private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        //find the source of bullets

        if (isEnemeyBullet == false)
        {
            rb2d.AddForce(Vector2.up * speed);//moving up
        }

        if (isEnemeyBullet == true)
        {
            rb2d.AddForce(Vector2.down  * speed);//moving down
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "AirCollider")
        {
            Debug.Log("hit the wall");
            //destry bullet
            Destroy(gameObject);
        }

        //bullet hit the enemy
        if (isEnemeyBullet == false)
        {
            if (col.gameObject.tag == "Enemy")
            {
                Debug.Log("hit the enemy");
                //destroy bullet & enemy
                //gameManager.enemyInScene.Remove(col.gameObject);
                //gameManager.CheckCanProceedToNextLevel();
                
                GameManager.instance.enemyInScene.Remove(col.gameObject);
                GameManager.instance.CheckCanProceedToNextLevel();
                
                Destroy(gameObject);
                Destroy(col.gameObject);
            }

        }

        //enemy bullet hit player
        if (isEnemeyBullet == true)
        {
            if (col.gameObject.tag == "Player")
            {
                Debug.Log("Plyer hurt");
                //destry bullet & enemy
                Destroy(gameObject);
            }
        }



    }

}