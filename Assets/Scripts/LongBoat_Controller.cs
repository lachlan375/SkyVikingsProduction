using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBoat_Controller : MonoBehaviour {

    public static bool activeControl;
    public bool boatOn;
	public GameObject boatObject;

	public Vector3 boatTransform;
    
    public Rigidbody rb;
	public  Vector3 rot;


	public float maxSpeed = 5f;
	public float rotSpeed = 180f;


	public static float dir;
	public float speedCurrent;		//Actual Longboat speed
    public static float tempSpeed;
    public bool tempSpeedPassed;
	public float turnSpeed;

	float moveHorizontal;
	float moveVertical;

	// Use this for initialization
	void Start () {
		rb = boatObject.GetComponent<Rigidbody> ();
        //activeControl = false;
	}



	void FixedUpdate ()
	{
		
		/*boatTransform = boatObject.transform;
		boatTransform = Vector3 (0, 0, speedCurrent * Time.deltaTime);
		boatObject.transform = boatTransform;*/

		// ROTATE the ship.

		//Grab our rotation quaternion
		Quaternion rot = boatObject.transform.rotation;

		// Grab the Z euler angle
		float y = rot.eulerAngles.y;

		// Change the Z angle based on input
		y -= dir * rotSpeed * Time.deltaTime;

		// Recreate the quaternion
		rot = Quaternion.Euler( 0, y, 0 );

		// Feed the quaternion into our rotation
		boatObject.transform.rotation = rot;

        // MOVE the ship.
        if (tempSpeed != speedCurrent) { 

            //if (tempSpeedPassed = true)
            //{

                Vector3 pos = transform.position;

                Vector3 velocity = new Vector3(0, tempSpeed * Time.deltaTime, 0);

                pos += rot * velocity;
                        
                boatObject.transform.Translate(Vector3.forward * tempSpeed * Time.deltaTime);
            //}
            //else
            //{
                
            //}
        }
    }

}