using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTrigger : MonoBehaviour {

    // Use this for initialization
    public GameObject canvasRef;
    public bool is_triggered = false;
    

    // Use this for initialization
    void Start()
    {
        canvasRef = transform.GetChild(0).gameObject;
        canvasRef.SetActive(is_triggered);
    }

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
