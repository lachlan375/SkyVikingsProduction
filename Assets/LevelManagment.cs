using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagment : MonoBehaviour {


    public static LevelManagment instance = null;
    // Use this for initialization
    void Start () {
        

    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {

            Destroy(gameObject);
        }

        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnSceneLoaded()
    {
        Debug.Log("New game level loaded");

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        
    }
}
