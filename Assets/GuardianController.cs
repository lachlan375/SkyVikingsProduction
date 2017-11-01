using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianController : MonoBehaviour {
	public GameObject canvasRef;
	public bool guardiansMode_Unlocked;

	// Use this for initialization
	void Start () {
		
	}

	public void HighStakesAccepted()
	{
		guardiansMode_Unlocked = true;
		//canvasRef;
	}

	public void HighStakesDeclined()
	{
		guardiansMode_Unlocked = false;
	}


}
