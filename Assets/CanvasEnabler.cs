using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanvasEnabler : MonoBehaviour
{

    public GameObject canvasRef;
    public UnityEvent onAnyKeyEvent;

    // Use this for initialization
    void Start()
    {
        canvasRef = gameObject;
    }

    // Update is called once per frame



    void Update()
    {
        if(Input.anyKeyDown == true)
        {
            if (canvasRef != null)
            {
                canvasRef.SetActive(false);
            }
            onAnyKeyEvent.Invoke();
        }
    }

    

}