using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransistion : MonoBehaviour {
    
    public int maxLevelInt; //Ref to store total value of Built levels
    public int currentLevelInt;

    public static SceneTransistion instance = null;


    public int index;
    private int transistionMode;
    public string levelName;

    

    public Image black;
    public Animator anim;



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


        //Find value of total number of levels
        
        maxLevelInt = SceneManager.sceneCountInBuildSettings;
        --maxLevelInt;
    }

    void OnSceneLoaded()
    {
        Debug.Log("On Scene Loaded");
        Debug.Log("New game level loaded");

    }

    public void SceneTransistionFunction(int transistionModeInput)
    {
        //will be a callable function that initiates transistion effect from 1 screen to another.
        //will perform a check to see what the purpose the transistion is
        //if 0 is called the quit game initiated, IF 1 then New Game, IF 3 then next level, IF 4 then restart current level

        transistionMode = transistionModeInput;
        /*if (transistionMode != 0)
        {*/
            switch (transistionMode)
            {
                case 5:
                    Debug.Log("Restart level");
                    break;

                case 4:
                    Debug.Log("Next level");
                    NextLevel();
                    break;
                case 3:
                    Debug.Log("Boss Level");

                    break;
                case 2:
                    Debug.Log("New Game");
                    index = 1;
                    break;
                case 1:
                    Debug.Log("Quit Game");
                    index = 0;
                    break;
                default:
                    Debug.Log("No choice has been made");
                    break;
            }
            StartCoroutine(Fading());
        //}

    }

    
    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        Debug.Log("Fade activated");
        yield return new WaitUntil(() => black.color.a >= .90);
        anim.SetBool("isfadeing", true);
        yield return new WaitUntil(() => black.color.a == 0);
        //yield return new WaitForSeconds(1);
        Debug.Log("Scene loaded");
        SceneManager.LoadScene(index);
		
    }
    

    void NextLevel()
    {
        if (currentLevelInt < maxLevelInt)
        {
            currentLevelInt++;
            SceneTransistionFunction(currentLevelInt);
        }
    }




}
