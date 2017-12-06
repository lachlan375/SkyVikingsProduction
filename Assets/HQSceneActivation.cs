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
        currentBoat = playerContRef.GetComponent<ShipStats>().currentShip;

        hqTransform = GameObject.FindGameObjectWithTag("Respawn").transform;

        //currentBoat = playerContRef.GetComponent<CurrentShip>().currentShip;



		origCam = GameObject.FindGameObjectWithTag("MainCamera");
		hqCam = GameObject.FindGameObjectWithTag("HQCamera");
        hqCam.SetActive(false);
        
        
        

    }

    // Update is called once per frame
    void Update()
    {
		if (is_ActiveHQMode) {
			HQActivation ();
			CameraSwitch_Off ();
		}

    }

    public void HQActivation()
    {

        playerContRef.GetComponent<ShipStats>().DeactivateCurrentShip();
        boatSelection_Range.SetActive(true);

		//is_switching = true;
        CameraSwitch_On ();


    }
    public void HQRelease()
    {
		boatSelection_Range.SetActive(false);
        //playerContRef.GetComponent<ShipStats>().ActivateCurrentShip();

		CameraSwitch_Off ();
		playerContRef.GetComponent<ShipStats>().ActivateCurrentShip();
    }

	public void CameraSwitch_On()
	{

		hqCam.SetActive (true);
		origCam.SetActive (false);
		Debug.Log ("HQ Cam activated!!!");
	}

	public void CameraSwitch_Off()
	{


		origCam.SetActive(true);
		hqCam.SetActive(false);
		Debug.Log ("HQ Cam activated!!!");
	}
		

}
