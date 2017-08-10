using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	public Transform target;            // The position that that camera will be following.
	public float smoothing;        // The speed with which the camera will be following.

	public Transform targetOrig;            // The position that that camera will be following.
	public float smoothingOrig;        // The speed with which the camera will be following.

	public Vector3 offset;                     // The initial offset from the target.



	void Start ()
	{
		// Calculate the initial offset.
		//offset = transform.position - target.position;

		//targetOrig = target;
		smoothingOrig = smoothing;
	}


	void FixedUpdate ()
	{
		// Create a postion the camera is aiming for based on the offset from the target.
		Vector3 targetCamPos = target.position + offset;
        Quaternion targetCamRot = target.rotation;

		// Smoothly interpolate between the camera's current position and it's target position.
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetCamRot, smoothing * Time.deltaTime);


	}
}



