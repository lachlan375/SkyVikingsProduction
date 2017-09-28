using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransistion : MonoBehaviour {
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
    }

    public void SceneTransistionFunction(int transistionModeInput)
    {
        //will be a callable function that initiates transistion effect from 1 screen to another.
        //will perform a check to see what the purpose the transistion is
        //if 0 is called the quit game initiated, IF 1 then New Game, IF 3 then next level, IF 4 then restart current level

        transistionMode = transistionModeInput;
        switch (transistionMode)
        {
            case 5:
                Debug.Log("Restart level");
                break;

            case 4:
                Debug.Log("Next level");
                index =+1;
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
                Debug.Log("No choice");
                break;
        }
        StartCoroutine(Fading());

    }


    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);

        
        SceneManager.LoadScene(index);
		Debug.Log ("Fade activated");
    }

    void NextLevel()
    {

    }




}
