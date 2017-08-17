using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowerController : MonoBehaviour {
    public MovementSVVertical movementVertical;
    public int movementCurrent;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        movementCurrent = movementVertical.currentSpeedInt;
    }
}
