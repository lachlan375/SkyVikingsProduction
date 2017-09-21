using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowerController : MonoBehaviour {

    public GameObject boatObject;
    public MovementSVVertical movementVertical;
    public int movementCurrent;

    public float[] speedAdditiveArray = new float[4];
	public float currentSpeedAdditive;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	public void RowStatUpdate (int movementInt) {
        movementCurrent = movementInt;
		currentSpeedAdditive = speedAdditiveArray [movementCurrent];
    }



	//check movement current.
	//if > 0 then

    public void Rowing()
    {
        if (movementCurrent > 0)
        {
			
        }
    }




}
