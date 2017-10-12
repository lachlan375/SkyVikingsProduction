using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuActivation : MonoBehaviour {
	public PauseMenuImproved pauseMenu;

	// Use this for initialization
	void Start () {
		pauseMenu = gameObject.GetComponent<PauseMenuImproved> ();

	}
	
	// Update is called once per frame
	void OnE () {
		if (gameObject.activeSelf == true) {
			pauseMenu.m_Paused = true;


		}
		else
		{
			pauseMenu.m_Paused = false;
		}
	}
}
