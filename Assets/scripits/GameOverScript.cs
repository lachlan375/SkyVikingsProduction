using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour {

    // Use this for initialization
    public GameObject gameOverCanvas;
    public GameObject normalCanvas;

    public void GameOverCanvas()
    {
        normalCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }


}
