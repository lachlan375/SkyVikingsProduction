using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTrigger : MonoBehaviour {

    // Use this for initialization
    public GameObject canvasRef;
    public UnityEvent onAnyKeyEvent;

    public Canvas merchantCanvas;

    // Use this for initialization
    void Start()
    {
        canvasRef = gameObject.transform.GetChild(0).Find("")
    }

    // Update is called once per frame



    void Update()
    {
        if (Input.anyKeyDown == true)
        {
            if (canvasRef != null)
            {
                canvasRef.SetActive(false);
            }
            onAnyKeyEvent.Invoke();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }

    }




}
