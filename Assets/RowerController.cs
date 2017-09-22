using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowerController : MonoBehaviour {

    public GameObject boatObject;
    public MovementSVVertical movementVertical;
    public int movementCurrentInt;


    public float[] rowingSpeedArray = new float[5];

    public float rowingSpeedMax;

    public float rowingSpeedCurrent;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	public void RowStatUpdate (int rowingSpeedInt) {

        Debug.Log("Rowing reference has been activated!!!");
        movementCurrentInt = rowingSpeedInt;
        rowingSpeedMax = rowingSpeedArray[movementCurrentInt];

    }




}
