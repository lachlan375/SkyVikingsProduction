using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentShip : MonoBehaviour
{

    //public GameObject instantiatedShip;
    public GameObject currentShip;

    //public Transform posShipCurrent;
    //public Transform posShipTransformTo;
    public Vector3 posHQRespawn;

    //public GameObject hqContRef;


    //public float spawnOffSet;

    public bool updatedShipModel;
    public bool testCall;



    // Use this for initialization
    void Start()
    {
        posHQRespawn = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        
        CurrentShipHQ_Spawn();
    }


    void Update()
    {
        if (testCall == true)
        {
            CurrentShipHQ_Spawn();
            testCall = false;
        }

    }

    public void CurrentShipHQ_Spawn()
    {
        if (updatedShipModel == true)
        {
            NewHQShip_Spawn();
            updatedShipModel = false;
        }

        else
        {
            currentShip.transform.position = posHQRespawn;

        }

        updatedShipModel = false;


    }

    void NewHQShip_Spawn()
    {

        Destroy(currentShip);

        currentShip = gameObject.GetComponent<ShipStats>().shipsArray[gameObject.GetComponent<ShipStats>().currentShip];


        Instantiate(currentShip);

        //pair currentship to gameobject tree as a child
        currentShip.transform.parent = transform;

        //currentShip.transform.position = posHQRespawn.transform.position;
    }



}
