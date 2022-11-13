using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PickUp : MonoBehaviour
{
    public GameObject dialogIcon;
    public GameObject flowchart;

    public int scriptIntVar;
    public Flowchart flowchartTest;

    private bool canTalk;

    private void Start()
    {
        flowchartTest = flowchart.GetComponent<Flowchart>();
        //scriptIntVar = flowchartTest.GetIntegerVariable("flowchartIntVar");
        flowchartTest.SetIntegerVariable("flowchartIntVar", scriptIntVar);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        dialogIcon.SetActive(true);
        canTalk = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        dialogIcon.SetActive(false);
        canTalk = false;
    }

    private void Update()
    {
        if (canTalk && Input.GetKeyDown(KeyCode.E))
        {
            flowchart.SetActive(true);
        }
    }
}
