using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHorizontal : MonoBehaviour {


	public float rotate;
    public float rotationClamp;
	public bool is_rotating;

    [Tooltip("For more natural turning, force will be applied this distance forward from the center of mass.")]
    public float turnForceOffset;

    public bool tiltFuction;
	public float tilt;

    
	public Quaternion originalRotation;
	public Quaternion toTransform;



	public Rigidbody rb;

    public float[] rotationVarArray = new float[5];
    public int currentSpeedInt;
    public int stationaryInt = 1;  //reference for idle position



    [Tooltip("Rotation time for tilting")]
    public float time;


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

        if (currentSpeedInt != stationaryInt)
        {
            rotate = Mathf.Clamp(rotate, -rotationClamp, rotationClamp);

            // work out the angle we should at due to our turning
            // TODO - make this stronger with forwards velocity
            float desiredZAngle = rotate * -25.0f;

            // and lerp towards it.
            float toTransformY = originalRotation.eulerAngles.y;
            toTransform = Quaternion.Euler(0.0f, toTransformY, desiredZAngle);

            rb.rotation = Quaternion.Slerp(originalRotation, toTransform, Time.deltaTime * time);

            originalRotation = rb.rotation;
        }

        if (rotate != 0)
        {
            //Rotate object using ADD Foce at Pos
            Vector3 forceAddPos = transform.position + rb.centerOfMass + (transform.forward * turnForceOffset);
            rb.AddForceAtPosition(transform.right * rotationVarArray[currentSpeedInt] * rotate, forceAddPos);

        }
    }

	//UPdate function called by other scripts to pass on current speed
	public void MoveHorizUpdate(int speedIntRef)
	{
		currentSpeedInt = speedIntRef;
	}


}
