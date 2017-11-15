using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowingAnim : MonoBehaviour {

    public ShipController shipController;

	public void SpeedStart()
	{
        shipController.oarsEngaged = true;
        shipController.numStrokes++;
	}

	public void SpeedDecay()
	{
        shipController.oarsEngaged = false;
    }


}


