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

    void SceneTransistionFunction(int transistionModeInput)
    {
        transistionMode = transistionModeInput;
        StartCoroutine(Fading());
    }


    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);
    }




}
