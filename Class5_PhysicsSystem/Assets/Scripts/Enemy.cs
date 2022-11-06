using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletPoint_E;
    public float Timer;
    public float FireRate;

    //public float TimeInterval;


    // Start is called before the first frame update
    void Start()
    {
        Timer = FireRate;
        GameManager.instance.enemyInScene.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            Timer = FireRate;
            Instantiate(bulletPrefab, bulletPoint_E.position, Quaternion.identity);
        }

        //Generate a bullet


    }
}
