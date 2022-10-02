//Library 库文件
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public 公有; private 私有

//Frame 帧; Update 
public class WasdController : MonoBehaviour
{
    public int A;

    public int B;

    public int C;

    public float Speed = 1.2f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Nate: Compare ABC
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CompareABC(A, B, C);
        }
        else
        {
            //Debug.Log("No Input!");
        }
        
        //Wasd Controller
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Moving Left");
            //Move Player to Left in Speed
            gameObject.transform.position = gameObject.transform.position + Vector3.left * Speed;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Moving Right");
            //Player moves right in certain speed
            gameObject.transform.position = gameObject.transform.position + Vector3.right * Speed;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Moving Up");
            //Move Player to Up in Speed
            gameObject.transform.position = gameObject.transform.position + Vector3.up * Speed;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Moving Down");
            //Player moves right in certain speed
            gameObject.transform.position = gameObject.transform.position + Vector3.down * Speed;
        }

    }

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
    
    //HomeWork Week2
    //尝试实现陨石循环移动
    //移动规则：从屏幕左侧StartingPoint出发，按照一定的速度Spped移动，一旦运动到屏幕右侧EndPoint，陨石传送回StartingPoint，继续移动
}
