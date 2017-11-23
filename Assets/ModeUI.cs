using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeUI : MonoBehaviour {

    public GameObject level_canvas;

    public GameObject bossStart_canvas;
    public GameObject gameOver_canvas;
    public GameObject gameQuit_canvas;
    public GameObject merchant_canvas;

    public int currentLevel;
	public int currentDayRef;
	public string currentLevelString;

	public Text levelStartText;
	public Text levelBossText;

    public bool testbool;

    // Use this for initialization
    void Start () {
		currentLevel = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<LevelManagment>().currentlevelInt;
        currentDayRef = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<LevelManagment>().dayCount;

    }
	
	// Update is called once per frame
	void Update () {


	}

    public void LevelUI_Start()
    {
		

		level_canvas.SetActive(true);
		currentLevel = CurrentLevelReturn ();
		levelStartText.text = "Level " + currentLevel + " Started";


    }

    public void LevelUI_Cont()
    {
        //LevelManagment.dayCount = LevelManagment.dayCount++;
		currentLevel = CurrentLevelReturn ();
        currentDayRef++;
		levelStartText.text = "Level " + currentLevel + " Day " + currentDayRef;
        level_canvas.SetActive(true);
    }

    public void BossUI_Start()
    {
		bossStart_canvas.SetActive(true);
		currentLevel = CurrentLevelReturn ();
        currentDayRef++;
        levelBossText.text = "Level " + currentLevel + " Enemy Guardian Awakened";

    }

    public void GameUI_Quit()
    {
        merchant_canvas.SetActive(false);
        gameQuit_canvas.SetActive(true);

    }

    public void GameUI_QuitCancel()
    {
        gameQuit_canvas.SetActive(false);
        merchant_canvas.SetActive(true);
    }

    public void GameUI_End()
    {
        gameOver_canvas.SetActive(true);

    }



	public int CurrentLevelReturn()
	{
		int levelInt;
		levelInt = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<LevelManagment>().currentlevelInt;
        levelInt = levelInt + 1;

        return levelInt;
	}


}
