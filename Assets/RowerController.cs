using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowerController : MonoBehaviour {

    public GameObject boatObject;
    public MovementSVVertical movementVertical;
    public int movementCurrent;

    public float[] speedRowVar = new float[4];

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	public void RowStatUpdate (int movementInt, float minSpeed ) {
        movementCurrent = movementInt;
    }

    public void Rowing()
    {
        if (movementCurrent > 0)
        {

        }
    }
}
