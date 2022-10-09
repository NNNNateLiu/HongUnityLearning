using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto_move : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;
    public float Speed = 0.002f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = StartPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x < EndPoint.position.x)
        { 
            gameObject.transform.position = gameObject.transform.position + Vector3.right * Speed;
            if (gameObject.transform.position.x > EndPoint.position.x)
            {
                print("bigger");
                gameObject.transform.position = StartPoint.position;
            }
        }
        else
        {
            gameObject.transform.position = gameObject.transform.position + Vector3.left * Speed;
            if (gameObject.transform.position.x < EndPoint.position.x)
            {
                print("smaller");
                gameObject.transform.position = StartPoint.position;
            }
        }

        print("position" + gameObject.transform.position);
    }
}
