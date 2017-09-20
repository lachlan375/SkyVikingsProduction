using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHorizontal : MonoBehaviour {

	//public Quaternion rot;
	//public float rotSpeed;
	//public float rotSpeedMin;

	//public float maxSpeed;

	float rotate;
	public bool is_rotating;

	public bool tiltFuction;
	public float tilt;


	float rotation;
	public Quaternion originalRotation;
	public Quaternion toTransform;



	//public GameObject boatObject;
	public Rigidbody rb;


	public int currentSpeedInt;

	//public float amount = 50.0f;
	public float[] amount = new float[4];

	public Transform thisTransform;
	public Vector3 startPos;
	public Vector3 endPos;
	public float time;




	[Tooltip("For more natural turning, force will be applied this distance forward from the center of mass.")]


	public float turnForceOffset;


	// Use this for initialization

	void Start()
	{
		rb = GetComponent<Rigidbody>();


	}

	// Update is called once per frame
	void FixedUpdate()
	{
		originalRotation = transform.rotation;

		rotate = Input.GetAxis ("Horizontal");

        if (currentSpeedInt > 0)
        {
            rotate = Mathf.Clamp(rotate, -0.450f, 0.450f);

            // work out the angle we should at due to our turning
            // TODO - make this stronger with forwards velocity
            float desiredZAngle = rotate * -45.0f;

            // and lerp towards it.
            float toTransformY = originalRotation.eulerAngles.y;
            toTransform = Quaternion.Euler(0.0f, toTransformY, desiredZAngle);

            rb.rotation = Quaternion.Slerp(originalRotation, toTransform, 0.5f);

            originalRotation = rb.rotation;
        }

        if (rotate != 0)
        {
            //Rotate object using ADD Foce at Pos
            Vector3 forceAddPos = transform.position + rb.centerOfMass + (transform.forward * turnForceOffset);
            rb.AddForceAtPosition(transform.right * amount[currentSpeedInt] * rotate, forceAddPos);

        }
    }

	//UPdate function called by other scripts to pass on current speed
	public void MoveHorizUpdate(int speedIntRef)
	{
		currentSpeedInt = speedIntRef;
	}


//public void TiltFunctionality()
//{

//rotation = rb.rotation.eulerAngles.y;
//rb.rotation = Quaternion.Euler(0.0f, rotation, GetComponent<Rigidbody>().velocity.x * -tilt);
//}


}
