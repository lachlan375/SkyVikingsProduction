using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class practivePublic : MonoBehaviour {
    public int hitHere;
    public GameObject []thing;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        difrentstuff();

    }
    public void names()
    {
        Debug.Log("hi" + hitHere);
    }

    public void difrentstuff()
    {
        switch(hitHere)
        {
            case 0:

                break;
            case 1:

                break;
        }
    }
    
}
