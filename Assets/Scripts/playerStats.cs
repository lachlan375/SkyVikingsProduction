using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerStatUpdate : MonoBehaviour {

    public static playerStatUpdate instance = null;

    public GameObject levelManager; //ref to actual level manager


    public bool isGameEnded = false; //flag to see if respect levels still above min


    public string Destination;

  

    [Header("Player Progress")]
    public int goldLevel;
    public int respectLevel;

	[Header("Ship Progress")]
	public int currentShip;


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
			//need to insert death/failure canvas
			//fade function
            levelManager.GetComponent<LevelManagment>().MainMenu();
        }
    }


}
