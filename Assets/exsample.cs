using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exsample : MonoBehaviour {
    public List<levels> stages = new List<levels>();
	// Use this for initialization
	void Start () {
        Debug.Log(stages[0].stage == 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
