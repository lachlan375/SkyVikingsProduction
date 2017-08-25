using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour {

    // Use this for initialization
    public Canvas gameOverCanvas;
    public Canvas normalCanvas;

    public void GameOverCall()
    {
        
        gameOverCanvas.enabled = true;
        normalCanvas.enabled = false;

    }

}
