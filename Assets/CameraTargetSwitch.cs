using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetSwitch : MonoBehaviour {

    public GameObject origCam;
    public GameObject hqCam;

    public GameObject currentCam;

  ///  public bool is_swtiching;





    void Awake()
    {



    }

    // Use this for initialization
    void Start()
    {

        //origCam = GameObject.FindGameObjectWithTag("MainCamera");
        //hqCam = GameObject.FindGameObjectWithTag("HQCamera");

    }

    void Update()
    {
        //CameraSwitch();
    }


    public void CameraSwitch(bool is_swtiching)
    {
        Debug.Log("camera switch called");
        if (is_swtiching)
        {
            
            hqCam.SetActive(true);
            origCam.SetActive(false);
            Debug.Log("HQ Cam activated!!!");
        }
        else
        {
            hqCam.SetActive(false);
            origCam.SetActive(true);
        }
    }


}
