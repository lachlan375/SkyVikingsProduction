using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSVVertical : MonoBehaviour {

	//Included Gameobject References
    //public GameObject boatObject;
    public Rigidbody rb;
	//public Transform boatTransform;
	//public ShipStats shipStatsObject;
    public RowerController rowObject;

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
        rowObject = GetComponent<RowerController>();
        //boatTransform = gameObject.transform;

        currentSpeedInt = 1;
    }

    //Function designed to USE length of Speed Array for the TotalSpeedCounter in Movement Controller
    //Called from Movement Controller
    public int VertInit()
    {
        //Setting up counter for Total Speed counter
        totalSpeedInt = speedVarArray.Length - 1;
        return totalSpeedInt;
    }

    void FixedUpdate()
	{
        
		//rb.AddForce (transform.forward * rowObject.rowingSpeedCurrent;
        rb.AddForce (transform.forward * speedVarArray[currentSpeedInt]);

    }
    //Function called from Movement Controller  to current class with latest INT counter
    public void MoveVertUpdate(int speedIntRef)
    {
        currentSpeedInt = speedIntRef;
        speedCurrentVal = speedVarArray[currentSpeedInt];
    }



}