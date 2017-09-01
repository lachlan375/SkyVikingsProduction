using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {


    public bool is_ActiveHQMode;        //flag to check if HQ Mode is active
                                        // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

        public void Exit()
    {
        Application.Quit();
    }




}
