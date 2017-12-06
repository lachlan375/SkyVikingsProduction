using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class ShipStats : MonoBehaviour
{
    public static ShipStats instance = null;
    //public float MaxHelth;
    [Tooltip("this just Determens  mouse sensativy right now")]
    public float handling;
    [Tooltip("how fast it takes to get to max speed")]

    public int rowingCrewCurrent;
    public int cargoBayCurrent;
    //public  GameObject [] shipsArray;


    public float rowingPower;
    public float weight;
    //[Tooltip("the speed of the ship be for weight")]
    public float maxSpeed;
    public float minSpeed;

	[Tooltip("Referencing Camera follow class")]
	public AbstractTargetFollower cameraFollowObject;

	public Transform currentShip_Transform;


	[Header("Ships List")]
    public int totalShips;
    //public int shipStateInt;

    public List<ShipStatsState> shippingList = new List<ShipStatsState>();

    [Header("Current Ship")]
    public int currentShipInt;
    public GameObject currentShip;

    public Vector3 posHQRespawn;


    public bool testbool;
    public int testInt;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {

            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

	/*
	public void NewShip()
	{
        if (currentShip >= 0 && currentShip < totalShips)
        {
            currentShip++;
            testbool = false;

        }
        else
            Debug.Log("Ship limit reached!!!");
        
    }*/

	void Start(){

		totalShips = transform.childCount;

		for(int i = 0; i < totalShips - 1; i++)
		{
			shippingList[i].Setup(i);

		}

        posHQRespawn = GameObject.FindGameObjectWithTag("Respawn").transform.position;

        currentShip = transform.GetChild(currentShipInt).gameObject;

		cameraFollowObject = GameObject.FindGameObjectWithTag ("MainCameraRoot").GetComponent<AbstractTargetFollower>();
        
    }

    void Update()
    {
        if (testbool == true)
        {
            UpdateCurrentShip(testInt);

            testbool = false;
        }

    }

    public void DeactivateCurrentShip()
    {
        currentShip.SetActive(false);
    }

	public void UpdateCurrentShip(int shipToActivate)
	{

        if (currentShipInt != shipToActivate)
        {
            currentShipInt = shipToActivate;
            currentShip = transform.GetChild(currentShipInt).gameObject;
        }

		else
			{
				currentShip = transform.GetChild(currentShipInt).gameObject;
			}
     
        //currentShip.SetActive(true);

        //currentShip.transform.position = posHQRespawn;



    }

    public void ActivateCurrentShip()
    {
        currentShip.SetActive(true);

        currentShip.transform.position = posHQRespawn;
		currentShip_Transform = currentShip.transform;
		cameraFollowObject.SetTarget (currentShip_Transform);

    }

	public void ResetActivatedShips()
	{
		for (int i = 0; i < totalShips; i++)
		{
			shippingList [i].is_activated = false;
		}
			
	}



}