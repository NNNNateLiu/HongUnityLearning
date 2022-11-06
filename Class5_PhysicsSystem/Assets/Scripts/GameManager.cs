using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);

            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    public List<GameObject> enemyInScene;
    public int nextSceneIndex;

    public void CheckCanProceedToNextLevel()
    {
        if (enemyInScene.Count == 0)
        {
            //Proceed to Next Scene
            SceneManager.LoadScene(nextSceneIndex);
            nextSceneIndex ++;
        }
    }
}
