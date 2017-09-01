using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQSetupScript : MonoBehaviour {

    public GameObject hqSetupLocation;
    public bool is_ActiveHQMode;        //flag to check if HQ Mode is active

    public GameObject hq_Cam;
    public GameObject actual_Cam;

	
    // Use this for initialization
	void Start () {
        hqSetupLocation = GameObject.FindGameObjectWithTag("Respawn");
        is_ActiveHQMode = false;
        actual_Cam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if (is_ActiveHQMode == true)
        {

        }

    }
}
