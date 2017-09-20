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
	public float tiltRetRotation = 10.0f;


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
		rotate = Mathf.Clamp (rotate, -0.250f, 0.250f);

		//CHECK to see what INPUT is
		if (rotate != 0) {

			//CHECK to if movement > 0 and Tilt function enabled
			if (currentSpeedInt != 0 && tiltFuction) {
				TiltFunctionality ();
			}

			is_rotating = true;


			//Rotate object using ADD Foce at Pos
			Vector3 forceAddPos = transform.position + rb.centerOfMass + (transform.forward * turnForceOffset);
			rb.AddForceAtPosition (transform.right * amount [currentSpeedInt] * rotate, forceAddPos);

		} else {
			if (is_rotating == true && tiltFuction) {
				TiltEnding ();
				is_rotating = false;
			}
				



		}
	}

	//UPdate function called by other scripts to pass on current speed
	public void MoveHorizUpdate(int speedIntRef)
	{
		currentSpeedInt = speedIntRef;
	}


	public void TiltFunctionality()
	{

		rotation = rb.rotation.eulerAngles.y;
		rb.rotation = Quaternion.Euler(0.0f, rotation, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

	public void TiltEnding()
	{



		float toTransformY = rb.rotation.y;

		toTransform = Quaternion.Euler (0.0f , toTransformY, 0.0f);

		float i = 0.0f;
		float rate = 2.0f/time;


		while (i < 1.0) {


			i += Time.deltaTime * rate;
			originalRotation = rb.rotation;


			//thisTransform.position = Vector3.Lerp (startPos, endPos, i);
			rb.rotation = Quaternion.Slerp(originalRotation, toTransform, i);

			Debug.Log ("Tilt ending has been activated");
		}




		/*rotation = rb.rotation.eulerAngles.y;
		rb.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);*/

		/*originalRotation.y = rb.rotation.y;
		originalRotation.x = 0;
		originalRotation.z = 0;

		float i = 0.0f;
		float rate = 2.0f/time;

		while (i < 1.0) {
			i += Time.deltaTime * rate;
			//thisTransform.position = Vector3.Lerp (startPos, endPos, i);
			rb.rotation = Quaternion.Lerp(transform.rotation, originalRotation, i);

		}*/







	}




}
