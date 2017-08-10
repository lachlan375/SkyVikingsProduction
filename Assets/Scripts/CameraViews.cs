using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViews : MonoBehaviour {

    public GameObject mainCam;
    private GameObject mainCamTarget;
    
    
    public int viewLength;
    int viewCurrent;
    int viewCurrentActual;

    public GameObject [] cameraViews;

    float viewInput;

    // Use this for initialization
    void Start () {
        mainCam = GameObject.Find("Main Camera");

        mainCam.GetComponent<cameraFollow>().target= cameraViews[0].transform;

        
        viewLength = cameraViews.Length;

        Debug.Log("amount of camera's is equal to " + viewLength);

    }

    // Update is called once per frame
    void FixedUpdate() {

        viewInput = Input.GetAxis("ViewChange");
        viewCurrentActual = viewCurrent + 1;

        if (Input.GetButtonDown("ViewChange"))
        {

            if (viewInput > 0)
            {
                Debug.Log("+Positive Input");

                if (viewCurrentActual < viewLength)
                {
                    viewCurrent++;
                    Debug.Log("+1 Input");
                }
                else
                {
                    viewCurrent = 0;
                    Debug.Log("Input has been reset");
                }
            }

            else if (viewInput < 0)
            {
                Debug.Log("+Negative Input");

                if (viewCurrentActual > 0)
                {
                    viewCurrent--;
                }
                else
                {
                    viewCurrent = viewLength;
                }
            }
            mainCam.GetComponent<cameraFollow>().target = cameraViews[viewCurrent].transform;
        }
    }
}
