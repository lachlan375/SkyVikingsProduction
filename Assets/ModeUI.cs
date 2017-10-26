using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeUI : MonoBehaviour {

    public GameObject level_canvas;
    public GameObject bossStart_canvas;
    public GameObject gameOver_canvas;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LevelUI_Start()
    {
        level_canvas.SetActive(true);
    }

    void LevelUI_End()
    {

    }

    public void BossUI_Start()
    {
        bossStart_canvas.SetActive(true);
    }

    public void GameUI_End()
    {
        gameOver_canvas.SetActive(true);

    }
}
