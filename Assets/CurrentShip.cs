using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentShip : MonoBehaviour {

	public GameObject instantiatedShip;
    public GameObject currentShip;

	public Transform posShipCurrent;
	public Transform posShipTransformTo;
	public Transform posHQRespawn;

	public GameObject hqContRef;


	public float spawnOffSet;

	public bool is_spawning;



	// Use this for initialization
	void Start () {
		posHQRespawn = GameObject.FindGameObjectWithTag("Respawn").transform;

        NewHQShip_Spawn();
    }
	

	void Update()
	{
        CurrentShipHQ_Spawn();
	}

    void ShipHQInstantiation()
    {
        if (currentShip != instantiatedShip)
        {
            NewHQShip_Spawn();
        }
        else
        {
            CurrentShipHQ_Spawn();
        }
    }

    void CurrentShipHQ_Spawn()
	{
		if (is_spawning == true) 
		{
            currentShip.transform.position = posHQRespawn.transform.position;
            is_spawning = false;
        }


	}

    void NewHQShip_Spawn()
    {
        Destroy(currentShip);

        instantiatedShip = gameObject.GetComponent<ShipStats>().shipsArray[gameObject.GetComponent<ShipStats>().currentShip];

        currentShip = instantiatedShip;
        currentShip = Instantiate(currentShip);
        currentShip.transform.parent = transform;

        currentShip.transform.position = posHQRespawn.transform.position;
    }

    void instantiatedShipUpdate()
    {

    }

}
