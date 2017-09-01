using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagment : MonoBehaviour {

    public int currentlevelInt;
    public int maxLevelInt;

    //public float[] levelRespect;
    //public Transform[] levelHQLocation;

    public static LevelManagment instance = null;

    public bool goto_NxtLevel;
    


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

    // Use this for initialization
    void Start ()
    {

        maxLevelInt = SceneManager.sceneCountInBuildSettings;
        --maxLevelInt;
        

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

    public void NextLevel()
    {
        if (currentlevelInt < maxLevelInt)
        {
            currentlevelInt++;
            SceneManager.LoadScene(currentlevelInt);
        }
    }

    public void Update() {

        if (goto_NxtLevel == true) {
            NextLevel();
        }
    }
}
