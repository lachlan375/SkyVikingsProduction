using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerStatUpdate : MonoBehaviour {
    public static playerStatUpdate instance = null;

    public GameObject levelManager; //ref to actual level manager


    public bool isGameEnded = false; //flag to see if respect levels still above min


    public string Destination;

    // [Header("boat cargo")]
    // public List<QestLog> curentQest = new List<QestLog>();
    // public List<QestLog> finshedQuests = new List<QestLog>();

    [Header("Player Progress")]
    public int goldLevel;
    public int respectLevel;

    private int counter;
    // Use this for initialization
    void Awake()
    {

        //Code that checks to see if there is already a instance of the same gameobject already existing.
        //Important for existing Singleton objects
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

    /*void OnSceneLoaded()
    {
        Debug.Log("New game level loaded");

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(this);
        }
    }*/

    void StatusUpdate(int goldUpdate, int respectUpdate)
    {
        goldLevel = goldUpdate;
        respectLevel = respectUpdate;

        if (respectLevel == 0)
        {

            Invoke("EndGame", 5);
        }
        else
        {
            isGameEnded = false;
        }
    }

    void EndGame()
    {
        
        if (!isGameEnded)
        {
            isGameEnded = true;
            levelManager.GetComponent<LevelManagment>().MainMenu();
        }
    }
    public void Update()
    {
        


    }
}
