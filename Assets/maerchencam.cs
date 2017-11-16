using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maerchencam : MonoBehaviour {
	// Use this for initialization
public void camraswich(Camera oldcamra,Camera newcam)
    {
        oldcamra.depth = 0;
        newcam.depth = 2;
    }
}
