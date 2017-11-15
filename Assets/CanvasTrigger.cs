using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTrigger : MonoBehaviour {

    // Use this for initialization
    public GameObject canvasRef;
    public bool is_triggered = false;

	public int childObject_ToUse;
    
	public bool loop_once;

    // Use this for initialization
    void Start()
    {
		
		canvasRef = transform.GetChild(childObject_ToUse).gameObject;
        canvasRef.SetActive(is_triggered);
    }

	//when Ontrigger is activated, activate canvas object in child transform
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            is_triggered = true;
            
        }
        canvasRef.SetActive(is_triggered);


    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            is_triggered = false;
        }
        canvasRef.SetActive(is_triggered);
    }




}
