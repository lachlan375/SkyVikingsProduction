using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeUI : MonoBehaviour {

    public GameObject level_canvas;

    public GameObject bossStart_canvas;
    public GameObject gameOver_canvas;

	public int currentLevel;
	public int currentDayRef;
	public string currentLevelString;

	public Text levelStartText;
	public Text levelBossText;

	public bool testbool;

    // Use this for initialization
    void Start () {
		currentLevel = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<LevelManagment>().currentlevelInt;
	}
	
	// Update is called once per frame
	void Update () {

		//

		/*if (testbool == true) 
		{
			LevelUI_Start ();
			//BossUI_Start ();
			testbool = false;

		}*/
	}

    public void LevelUI_Start()
    {
		

		level_canvas.SetActive(true);
		currentLevel = CurrentLevelReturn ();
		levelStartText.text = "Level " + currentLevel + " Started";


    }

    public void LevelUI_Cont()
    {
		level_canvas.SetActive(true);
		currentLevel = CurrentLevelReturn ();
		currentDayRef = CurrentDayCount ();
		levelStartText.text = "Level " + currentLevel + " Day " + currentDayRef;
    }

    public void BossUI_Start()
    {
		bossStart_canvas.SetActive(true);
		currentLevel = CurrentLevelReturn ();

		levelBossText.text = "Level " + currentLevel + " Enemy Guardian Awakened";



    }

    public void GameUI_End()
    {
        gameOver_canvas.SetActive(true);

    }

	public int CurrentLevelReturn()
	{
		int levelInt;
		levelInt = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<LevelManagment>().currentlevelInt;
		return levelInt;
	}

	public int CurrentDayCount()
	{
		int dayInt;
		dayInt = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<LevelManagment>().dayCount;
		return dayInt;
	}
}
