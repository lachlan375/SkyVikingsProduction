﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunAndmoon : MonoBehaviour {
    public bool TimeStop;
    public float speed;
    public GameObject sun;
    public GameObject moon;
    public GameObject endDay;  

	public bool endDay_Triggered = false;

 	// Use this for initialization
	void Start () {
 
    }

    // Update is called once per frame
    void Update () {

		if(TimeStop == false)
        {
            sun.transform.LookAt(transform.position);
            moon.transform.LookAt(transform.position);
            transform.Rotate(Vector3.right *speed*Time.deltaTime);
             Vector3 Angles = transform.eulerAngles;
            transform.eulerAngles = Angles;
			if (Angles.x >= 180) {
				if (endDay_Triggered == false) {
					dayoverScreen ();
					endDay_Triggered = true;
				}
				Debug.Log ("end day");
 
			} else
				endDay_Triggered = false;
        }

    }
    public void andStop()
    {
        TimeStop = !TimeStop;
    }
    public void dayoverScreen()
    {
        //Time.timeScale = 0;
        endDay.SetActive(true);
        Time.timeScale = 0;
        //TimeStop = true;

    }
    public void moveThesun()
    {
        sun.transform.LookAt(transform.position);
        moon.transform.LookAt(transform.position);
        transform.Rotate(0, 0, 180);
        Debug.Log("hit");
    }
}
