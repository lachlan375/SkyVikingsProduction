using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatStatOverview : MonoBehaviour {

    public int maxCargoLimit;

    public float thrust;
    

    [Tooltip("Cost to pu8rchase boat")]
    public int boatValue;


	// Use this for initialization
	void Start () {
        thrust = GetComponent<ShipController>().thrust;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
