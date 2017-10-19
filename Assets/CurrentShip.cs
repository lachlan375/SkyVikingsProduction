using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentShip : MonoBehaviour {

	public GameObject instantiatedShip;

	public Transform posShipCurrent;
	public Transform posShipTransformTo;
	public Transform posHQRespawn;

	public GameObject hqContRef;


	public float spawnOffSet;

	public bool is_spawning;



	// Use this for initialization
	void Start () {
		
		instantiatedShip = gameObject.GetComponent<ShipStats> ().shipsArray [gameObject.GetComponent<ShipStats> ().currentShip];

		//posHQRespawn = hqContRef.GetComponent<HQSetupScript> ().hqSetupTransform;


	}
	

	void Update()
	{
		SpawnShipHQ ();
	}

	void SpawnShipHQ()
	{
		if (is_spawning == true) 
		{
			//instantiatedShip.GetComponent<Transform>().transform = posHQRespawn;
		}
	}
}
