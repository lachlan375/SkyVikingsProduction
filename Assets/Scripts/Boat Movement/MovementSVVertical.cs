using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSVVertical : MonoBehaviour {

	//Included Gameobject References
    //public GameObject boatObject;
    public Rigidbody rb;
	//public Transform boatTransform;
	//public ShipStats shipStatsObject;
	public Rowing rowObject;
	public Animator rowerAnim;

	//Speed References
	public int currentSpeedInt; //ref for Current SpeedVar array
	[Tooltip("Array to store BASE speeds of boat.  Will be sent to movement controller in init function")]
	public float[] minSpeedArray = new float[5];
	public float speedCurrentVal;

	[Tooltip("From BASE speed to ROWING speed")]
	public float[] rowingSpeedArray = new float[5];
	public float rowingCurrentVal;

	public float rowingSpeedMax;
	public int rowingSpeedInt;

	public float rowingPower;

    public bool rowingPausedCheck;
    public bool movingCheck;
    
    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();

        currentSpeedInt = 1;
    }

	//Function designed to USE length of Speed Array for the TotalSpeedCounter in Movement Controller
	//Called from Movement Controller
	public int VertInit()
	{
		//Setting up counter for Total Speed counter
		rowingSpeedInt = rowingSpeedArray.Length - 1;
		return rowingSpeedInt;
	}


	void FixedUpdate()
	{
		
		//rb.AddForce (transform.forward * rowObject.rowingSpeedCurrent;
		//rb.AddForce (transform.forward * speedVarArray[currentSpeedInt]);
		rb.AddForce (transform.forward * rowingCurrentVal);
	}


    //Function called from Movement Controller  to current class with latest INT counter
    public void MoveVertUpdate(int speedIntRef, bool is_rowingPaused, bool is_moving /*, bool is_reversing*/)
    {
        currentSpeedInt = speedIntRef;
        speedCurrentVal = minSpeedArray[currentSpeedInt];
		rowingCurrentVal = rowingSpeedArray [currentSpeedInt];

        rowingPausedCheck = is_rowingPaused;

        movingCheck = is_moving;
    }



}