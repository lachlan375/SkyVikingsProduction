using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSVVertical : MonoBehaviour {

	//Included Gameobject References
    public GameObject boatObject;
    public Rigidbody rb;
	public ShipStats shipStatsObject;
    public RowerController rowObject;

	//Speed References
    
	[Tooltip("Array to store BASE speeds of boat")]
	public float[] speedVar = new float[4];
	public int currentSpeedInt; //ref for Current SpeedVar array
	public int totalSpeedInt;	//TOTAL length counter SpeedVar array
    public float speedConverted;

	//Movement References
	public float moveVertical;	// counter to save Vertical Input axis
	public bool movingCheck;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();

        //speedVar = new float[] { 0.0f, 10000.0f, 30000.0f, 50000.0f };
		currentSpeedInt = 0;
		totalSpeedInt = speedVar.Length - 1;
    }

	void FixedUpdate()
	{
		if (Input.GetButtonDown ("Vertical"))
		{
			
			Debug.Log("Debug log ACTIVATED");
			moveVertical = Input.GetAxis("Vertical");

			if (moveVertical > 0)
			{
				if (currentSpeedInt < totalSpeedInt) {
					Debug.Log ("Current Speed increased!!!");
					currentSpeedInt++;
					movingCheck = true;
				} else
				{
					Debug.Log ("Speed limit Reached!!!");
				}
			}

			//Checking to see IF GOING BACKWARD
			else if (moveVertical < -0)
			{
				if (currentSpeedInt > 0)
				{
					Debug.Log("Current Speed slowed down!!!");
					currentSpeedInt --;
				}
				else
				{
					Debug.Log ("Speed levels at Minimum acceptable level");
					movingCheck = false;
				}
			}


			Debug.Log("Vertical Axis is " + moveVertical);
			Debug.Log("Current speed selection is " + currentSpeedInt + " at a FORCE Rating of " + speedVar[currentSpeedInt]);
		}
        rowObject.RowStatUpdate(currentSpeedInt, speedConverted);
		rb.AddForce (transform.forward * speedVar[currentSpeedInt]);
	}

}