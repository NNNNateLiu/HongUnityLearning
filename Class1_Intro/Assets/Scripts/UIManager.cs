using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image img_Life_1;
    public Image img_Life_2;
    public Image img_Life_3;

    public GameObject but_Restart;

    public Text txt_Score;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {
        txt_Score.text = "Score: " + score;
    }
}
