using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraTargetSwitch : MonoBehaviour {

    public GameObject origCam;
    public GameObject hqCam;

	public Image black;
	public Animator anim;

	private bool is_switching;


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

    

    public void CameraSwitch()
    {
        
        Debug.Log("camera switch called");
        if (!is_switching)
        {

            hqCam.SetActive(true);
            origCam.SetActive(false);
            Debug.Log("HQ Cam activated!!!");
			is_switching = true;
        }
        else
        {
            hqCam.SetActive(false);
            origCam.SetActive(true);
			is_switching = false;
        }
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
