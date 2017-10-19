using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowingAnim : MonoBehaviour {

	public Rowing rowingRef;

	// Use this for initialization


	public void SpeedStart()
	{
		rowingRef.slow = false;
		Debug.Log ("Oars in FAST mode");
	}

	public void SpeedDecay()
	{
		rowingRef.slow = true;
		Debug.Log ("Oars in SPEED mode");
	}


}


