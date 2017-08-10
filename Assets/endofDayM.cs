using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class endofDayM : MonoBehaviour {
    public Text theText;
    public float sundown;
    public Transform sun;
    public GameObject end;
 	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (sun.transform.position.y <= sundown)
        {
         //   end.SetActive(true);
            
        }
   }
}
