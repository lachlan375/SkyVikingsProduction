using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSVVertical : MonoBehaviour {

	//Included Gameobject References
    //public GameObject boatObject;
    public Rigidbody rb;
	//public Transform boatTransform;
	//public ShipStats shipStatsObject;
    //public RowerController rowObject;

	//Speed References
    
	[Tooltip("Array to store BASE speeds of boat.  Will be sent to movement controller in init function")]
	public float[] speedVarArray = new float[5];
	public int currentSpeedInt; //ref for Current SpeedVar array
	public int totalSpeedInt;	//TOTAL length counter SpeedVar array

    public float speedCurrentVal;
    //public float speedConverted;

    public bool movingCheck;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
		//boatTransform = gameObject.transform;

		currentSpeedInt = 1;
		
    }

	void FixedUpdate()
	{
        //rowObject.RowStatUpdate(currentSpeedInt, speedConverted);
		rb.AddForce (transform.forward * speedVarArray[currentSpeedInt]);

	}

    public void MoveVertUpdate(int speedIntRef)
    {
        currentSpeedInt = speedIntRef;
        speedCurrentVal = speedVarArray[currentSpeedInt];
    }

    //Function designed to USE length of Speed Array for the TotalSpeedCounter in Movement Controller
    public int VertInit()
    {
        totalSpeedInt = speedVarArray.Length - 1;
        return totalSpeedInt;
    }

}