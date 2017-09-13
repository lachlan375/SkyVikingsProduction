using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiningOrb : MonoBehaviour {
    public float speed;
	// Use this for initialization

	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, speed, 0);
    }
}
