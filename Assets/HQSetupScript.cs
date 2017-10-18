using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HQSetupScript : MonoBehaviour {

    private GameObject hqSetupObject;
    public Transform hqSetupTransform;
    public bool is_ActiveHQMode;        //flag to check if HQ Mode is active

    //public GameObject longBoat;
    
    
	
    // Use this for initialization
	void Start () {
        hqSetupObject = GameObject.FindGameObjectWithTag("Respawn");
        hqSetupTransform = hqSetupObject.transform;


	}
	
	// Update is called once per frame
	void Update () {

    }

    

}
