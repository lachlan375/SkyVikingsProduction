using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowerController : MonoBehaviour {

    public GameObject boatObject;
    public MovementSVVertical movementVertical;
    public int movementCurrent;

    public float[] rowingSpeedArray = new float[5];
    public float[] timeRowingBeat = new float[5];
    public float[] timeRowingTotalBeat = new float[5];

    public float rowingSpeedCurrent;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	public void RowStatUpdate (int movementInt) {
        movementCurrent = movementInt;
		
    }



	//check movement current.
	//if > 0 then

    public void Rowing()
    {
        rowingSpeedCurrent = rowingSpeedArray[movementCurrent];

        Debug.Log("Current Rowing Speed is" + rowingSpeedCurrent);



    }




}
