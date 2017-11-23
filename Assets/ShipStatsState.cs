using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]


public class ShipStatsState {

	public GameObject boat;

	public int unlock_level;
	public int unlock_cost;

	public bool is_unlocked;

	public bool is_owned;

    public bool is_activated;

	// Use this for initialization


	public void Setup(int currentBoat)
	{
		//boat = gameObject.transform.GetChild (currentBoat);
		Debug.Log("Boat " + currentBoat + " created");


	}


}
