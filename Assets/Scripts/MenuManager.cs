using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public int index;
    public bool is_ActiveHQMode;        //flag to check if HQ Mode is active
                                        // Use this for initialization
    public SceneTransistion sceneTransitRef;
                                            
    void Start () {
        sceneTransitRef = gameObject.GetComponent<SceneTransistion>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGame()
    {
        sceneTransitRef.SceneTransistionFunction(2);

       
    }

        public void Exit()
    {
        Application.Quit();
    }




}
