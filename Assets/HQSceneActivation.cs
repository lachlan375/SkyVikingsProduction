using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HQSceneActivation : MonoBehaviour {

    
    public Transform hqTransform;
    public bool is_ActiveHQMode;        //flag to check if HQ Mode is active

    public GameObject playerContRef;
    public GameObject currentBoat;
    Vector3 spawn;

    

    public Scene hq_Scene;
    public string hqString;


    // Use this for initialization
    void Start()
    {
        spawn = currentBoat.transform.position;
        playerContRef = GameObject.FindGameObjectWithTag("GameController");
        currentBoat = playerContRef.GetComponent<CurrentShip>().currentShip;

        hqTransform = GameObject.FindGameObjectWithTag("Respawn").transform;

        currentBoat = playerContRef.GetComponent<CurrentShip>().currentShip;


        
        
        

    }

    // Update is called once per frame
    void Update()
    {
        if (is_ActiveHQMode)
        {
            HQActivation();
			is_ActiveHQMode = false;
        }


    }

    public void HQActivation()
    {

        //gameObject.GetComponent<CameraTargetSwitch>().CameraSwitch(true);
        currentBoat.transform.position = spawn;
		playerContRef.GetComponent<MovementInputController> ().MovementReset();
        //currentBoat.transform.position = findobject. hqTransform.transform.position;
        playerContRef.GetComponent<CurrentShip>().CurrentShipHQ_Spawn();

        //GameObject.FindGameObjectWithTag("PlayerController").GetComponent<CurrentShip>().CurrentShipHQ_Spawn();
        

        //GetComponent<CurrentShip>().transform.position = 

        //freeze animation + lock boat
        //particle effect

    }
    public void HQRelease()
    {

        //gameObject.GetComponent<CameraTargetSwitch>().CameraSwitch(false);

    }

    public void HQNewBoat()
    {

    }
}
