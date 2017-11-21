using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	[Header("Ship Progress")]
	//public int currentShip;
	public int totalShips;


	[Header("Current Ship")]


	//public int shipStateInt;

	public List<ShipStatsState> shippingList = new List<ShipStatsState>();

    public bool testbool;

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
	}

	public void UpdateCurrentShip(int shiptoactivate)
	{
		
	}




}