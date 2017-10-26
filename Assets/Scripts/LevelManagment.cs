using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagment : MonoBehaviour {

    public int currentlevelInt;
    public int maxLevelInt;

    public GameObject animObjectRef;
    public Image black;
    public Animator anim;

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
        //Redundant code transferred to Scene Transition class
       // maxLevelInt = SceneManager.sceneCountInBuildSettings;
        //--maxLevelInt;
        

    }

    void Update()
    {
        if (goto_NxtLevel== true)
        {
            MainMenu();
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
        StartCoroutine(Fading());
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        if (currentlevelInt < maxLevelInt)
        {
            currentlevelInt++;
            StartCoroutine(Fading());

            SceneManager.LoadScene(currentlevelInt);
        }
    }

  
    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        //Debug.Log("Fade activated");
        yield return new WaitUntil(() => black.color.a >= .95);
        anim.SetBool("isfadeing", true);
        yield return new WaitUntil(() => black.color.a == 0);

    }


}
