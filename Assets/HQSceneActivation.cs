using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HQSceneActivation : MonoBehaviour {

    
    public Transform hqTransform;
    public bool is_ActiveHQMode;        //flag to check if HQ Mode is active

    public GameObject playerContRef;
    public GameObject currentBoat;

    public GameObject boatSelection_Range;

    Vector3 spawn;



	public GameObject hqCam;
	public GameObject origCam;
	private bool is_switching;

    //public Scene hq_Scene;
    //public string hqString;


    // Use this for initialization
    void Start()
    {
        spawn = currentBoat.transform.position;
        playerContRef = GameObject.FindGameObjectWithTag("GameController");
        currentBoat = playerContRef.GetComponent<CurrentShip>().currentShip;

        hqTransform = GameObject.FindGameObjectWithTag("Respawn").transform;

        currentBoat = playerContRef.GetComponent<CurrentShip>().currentShip;



		origCam = GameObject.FindGameObjectWithTag("MainCamera");
		hqCam = GameObject.FindGameObjectWithTag("HQCamera");
        hqCam.SetActive(false);
        
        
        

    }

    // Update is called once per frame
    void Update()
    {
		if (is_ActiveHQMode) {
			HQActivation ();
			CameraSwitch ();
		}

    }

    public void HQActivation()
    {

        playerContRef.GetComponent<ShipStats>().DeactivateCurrentShip();
        boatSelection_Range.SetActive(true);


        CameraSwitch ();


    }
    public void HQRelease()
    {

        playerContRef.GetComponent<ShipStats>().ActivateCurrentShip();
        boatSelection_Range.SetActive(false);
        CameraSwitch ();
    }

	public void CameraSwitch()
	{

		Debug.Log("camera switch called");
		if (!is_switching)
		{

			hqCam.SetActive(true);
			origCam.SetActive(false);
			Debug.Log("HQ Cam activated!!!");
			is_switching = true;
		}
		else
		{
			hqCam.SetActive(false);
			origCam.SetActive(true);
			is_switching = false;
		}
	}

}
