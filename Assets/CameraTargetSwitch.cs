using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraTargetSwitch : MonoBehaviour {

    public GameObject origCam;
    public GameObject hqCam;

	public Image black;
	public Animator anim;




    void Awake()
    {



    }

    // Use this for initialization
    void Start()
    {
		//was going to use this code, but can't find HQCamera if object is not visible
        origCam = GameObject.FindGameObjectWithTag("MainCamera");
        hqCam = GameObject.FindGameObjectWithTag("HQCamera");

    }

    

    public void CameraSwitch(bool is_swtiching)
    {
        /*
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
        }*/
    }

	IEnumerator Fading()
	{
		anim.SetBool("Fade", true);
		Debug.Log("Fade activated");
		yield return new WaitUntil(() => black.color.a >= .95);
		anim.SetBool("isfadeing", true);
		yield return new WaitUntil(() => black.color.a == 0);


	}


}
