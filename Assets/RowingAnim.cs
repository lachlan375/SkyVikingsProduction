using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowingAnim : MonoBehaviour {

	public Rowing rowingRef;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}






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


