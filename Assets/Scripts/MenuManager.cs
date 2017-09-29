using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public int index;
    public bool is_ActiveHQMode;        //flag to check if HQ Mode is active
                                        // Use this for initialization
    public SceneTransistion sceneTransitRef;

    public int newGame = 2;
                                            
    void Start () {
        sceneTransitRef = gameObject.GetComponent<SceneTransistion>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGame()
    {
        sceneTransitRef.SceneTransistionFunction(newGame);

       
    }

        public void Exit()
    {
        Application.Quit();
    }




}
