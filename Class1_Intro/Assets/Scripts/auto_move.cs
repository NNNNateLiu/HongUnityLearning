using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.MPE;
using UnityEngine;

public class auto_move : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;
    public float Speed = 0.002f;

    public bool isLeftMovingStone;

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
                    print("smaller");
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
                    print("bigger");
                    gameObject.transform.position = StartPoint.position;
                }
            }
        }
    }
}


