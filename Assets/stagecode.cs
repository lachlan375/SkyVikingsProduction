using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stagecode : MonoBehaviour {
    public exsample memeroy;
	// Use this for initialization
	void Start () {
        memeroy = FindObjectOfType<exsample>();

        stagestuff();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void stagestuff()
    {
        switch (memeroy.stages[0].stage)
        {
            case 1:
                Debug.Log("hi");
                break;

        }


    }
}
