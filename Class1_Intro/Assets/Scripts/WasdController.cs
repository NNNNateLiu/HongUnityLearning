//Library 库文件
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public 公有; private 私有

//Frame 帧; Update 

public class WasdController : MonoBehaviour
{
    /*
    public int A;

    public int B;

    public int C;
    */

    public Transform playerStartPoint;
    public float Speed = 1.2f;
    public int life = 3;
    public int score = 0;
    public int amount = 3;
    private float defendTime = 0f;
    private float generateTime = 15f;
    //private bool isDefended = true;
    public GameObject Life_1, Life_2, Life_3;
    public GameObject AddLife;
    public GameObject AddPoint;
    public GameObject Shield;
    public GameObject RocketShield;
    public GameObject art;
    public GameObject Stone;
    public Component[] colliders;
    public UIManager uiManager;

    private int i;

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


        //regenerate Shield
        if (Shield.activeSelf is false )
        {
            generateTime -= Time.deltaTime;
            if (generateTime < 0)
            {
                generateTime = 10f;
                Debug.Log("5s");
                Shield.SetActive(true);
                Shield.transform.position = new Vector2(Random.Range(-8f, 8f), Random.Range(-3f, 3f));
            }
        }

        // Shield effect
        if (defendTime > 0)
        {
            RocketShield.SetActive(true);
            defendTime -= Time.deltaTime;
            Stone = GameObject.FindGameObjectWithTag("StoneGroup");
            colliders = Stone.GetComponentsInChildren<BoxCollider2D>();
            Debug.Log("count: " + colliders.Length);
            //foreach, for, while
            //i = 0,1,2,3,4,5
            
            //For 循环
            /*
            for (int i = 0; i <= colliders.Length; i++)
            {
                colliders[i].GetComponent<BoxCollider2D>().enabled = false;
                
                Debug.Log("i = " + i);
                Debug.Log(colliders[i].name);
        
            }*/
            
            
            //While 循环
            /*
            while (i < colliders.Length)
            {
                colliders[i].GetComponent<BoxCollider2D>().enabled = false;
                i++;
            }
            */
            
            /*
            foreach (BoxCollider2D collider in colliders)
                collider.enabled = false;//禁用碰撞组件
            Debug.Log("无敌模式");
            */
        }
        else
        {
            RocketShield.SetActive(false);
            Stone = GameObject.FindGameObjectWithTag("StoneGroup");
            colliders = Stone.GetComponentsInChildren<BoxCollider2D>();
            foreach (BoxCollider2D collider in colliders)
                collider.enabled = true;//启用碰撞组件
            //Debug.Log("不是无敌模式");
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
    */

    /*
    //player collision
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Stone")
        {
            life--;
            gameObject.transform.position = playerStartPoint.position;
        }
    }
    */

 

    //player triggerbox & finish 
    private void OnTriggerEnter2D(Collider2D col)
    {
        //player hit the stone
        if (col.gameObject.tag == "Stone")
        {
            Debug.Log("hurt");
            life--;
            Life();
            gameObject.transform.position = playerStartPoint.position;
        }

        //player hit the special stone
        if (col.gameObject.tag == "Special_Stone")
        {
            Debug.Log("hurt");
            life-=2;
            Life();
            gameObject.transform.position = playerStartPoint.position;
        }

        // player get the life item
        if (col.gameObject.tag == "Add_Life")
        {
            Debug.Log("heal");
            //player gain 1 life
            if (life < 3)
            {
                life++;
            }
            
            Life();
            col.gameObject.SetActive(false);

        }

        // player get the point item
        if (col.gameObject.tag == "Add_Point")
        {
            Debug.Log("get point");
            //player gain 1 score
            score++;
            //Update txt_Score
            uiManager.UpdateScore(score);
            col.gameObject.SetActive(false);

        }

        // player reach the shield
        if (col.gameObject.tag == "Shield")
        {
            Debug.Log("get shield");
            col.gameObject.SetActive(false);
            defendTime = 5f;
            

        }


        // player reach the finish point
        if (col.gameObject.tag == "Finish")
        {
            Debug.Log("win!");
            //set player back to startpoint
            gameObject.transform.position = playerStartPoint.position;
            //player gain 1 score
            score++;
            //Update txt_Score
            uiManager.UpdateScore(score);
            AddLife.SetActive(true);
            AddPoint.SetActive(true);
            AddLife.transform.position = new Vector2(Random.Range(-8f, 8f), Random.Range(-3f, 3f));
        }



        
    }

    //player life system
    public void Life()
    {

        if (life > 2)
        {
            uiManager.img_Life_1.color = Color.red;
            uiManager.img_Life_2.color = Color.red;
            uiManager.img_Life_3.color = Color.red;
            Debug.Log("life=3");
        }
        if (life == 2)
        {
            uiManager.img_Life_1.color = Color.red;
            uiManager.img_Life_2.color = Color.red;
            uiManager.img_Life_3.color = Color.black;
            Debug.Log("life=2");
        }

        if (life == 1)
        {
            uiManager.img_Life_1.color = Color.red;
            uiManager.img_Life_2.color = Color.black;
            uiManager.img_Life_3.color = Color.black;

            Debug.Log("life=1");
        }

        if (life < 1)
        {
            uiManager.img_Life_3.color = Color.black;
            uiManager.img_Life_2.color = Color.black;
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

    //初始化
    public void Initialization()
    {
        gameObject.transform.position = playerStartPoint.position;
        //generate item
        AddLife.SetActive(true);
        AddLife.transform.position = new Vector2(Random.Range(-8f, 8f), Random.Range(-3f, 3f));
        AddPoint.SetActive(true);
        AddPoint.transform.position = new Vector2(Random.Range(-8f, 8f), Random.Range(-3f, 3f));
        Shield.SetActive(true);
        Shield.transform.position = new Vector2(Random.Range(-8f, 8f), Random.Range(-3f, 3f));
        //score
        uiManager.UpdateScore(0);
        uiManager.UpdateSkill(3);
        art.SetActive(true);
        uiManager.img_Life_1.color = Color.white;
        uiManager.img_Life_2.color = Color.white;
        uiManager.img_Life_3.color = Color.white;
        uiManager.but_Restart.SetActive(false);
        //skill
        uiManager.but_Lowspeed.SetActive(true);
        life = 3;
        score = 0;
        amount = 3;
    }
    
    //Homework4
    //结合前三节课所学（input、Collider&Trigger、UI）给Space Race做一个特性

}