using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerStats : MonoBehaviour {
    public static playerStats instance = null;


    [Header("boat cargo")]
     public List<QestLog> curentQest = new List<QestLog>();
    public List<QestLog> finshedQuests = new List<QestLog>();

    [Header("Player Progress")]
    public int goldLevel;
    public int respectLevel;

    private int couter;
    // Use this for initialization
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

        DontDestroyOnLoad(gameObject);
        
    }

    void StatusUpdate(int goldUpdate, int respectUpdate)
    {
        goldLevel = goldUpdate;
        respectLevel = respectUpdate;

        if (respectLevel == 0)
        {
            gameObject.GetComponent<GameOverScript>().GameOverCall();
        }
    }
    public void Update()
    {
        StatusUpdate(2, 0);


    }
}
