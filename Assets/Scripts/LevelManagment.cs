using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagment : MonoBehaviour
{

    public int currentlevelInt;
    public int maxLevelInt;

    public int dayCount;

    public GameObject animObjectRef;
    public Image black;
    public Animator anim;

    public static LevelManagment instance = null;

    public int[] unlock_BossMode = new int[3];


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
    void Start()
    {

        dayCount = 0;
        //Redundant code transferred to Scene Transition class
        // maxLevelInt = SceneManager.sceneCountInBuildSettings;
        //--maxLevelInt;


    }

    void Update()
    {
        if (goto_NxtLevel == true)
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
        //StartCoroutine(Fading());
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        if (currentlevelInt < maxLevelInt)
        {
            currentlevelInt++;
            //StartCoroutine(Fading());

            SceneManager.LoadScene(currentlevelInt);
        }
    }

    public void Level01To02()
    {
        StartCoroutine(Fading01());
    }

    public void Level02To03()
    {
        StartCoroutine(Fading02());
    }

    public void QuitToMenu()
    {
        StartCoroutine(FadingMenu());
    }

    IEnumerator Fading01()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a >= .95);
        anim.SetBool("isfadeing", true);
        SceneNames.LoadScene("Level_02");
    }

    IEnumerator Fading02()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a >= .95);
        anim.SetBool("isfadeing", true);
        SceneNames.LoadScene("Level_03");
    }

    IEnumerator FadingMenu()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a >= .95);
        anim.SetBool("isfadeing", true);
        SceneNames.LoadScene("MenuTest");
    }

}
