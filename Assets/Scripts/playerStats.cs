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
    public int goldlevel;
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

    // Update is called once per frame
    void Update() {

    }
    public void checkWait()
    {

     
    }
}
