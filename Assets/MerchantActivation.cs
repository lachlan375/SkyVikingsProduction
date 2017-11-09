using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantActivation : MonoBehaviour {

    public Animator merchant_anim;
    public string animParameter_Title;
    public bool animParameter_Value;
    

	// Use this for initialization
	void Start () {
        merchant_anim = gameObject.GetComponent<Animator>();
	}
	
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            merchant_anim.SetBool(animParameter_Title, !animParameter_Value);
        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            merchant_anim.SetBool(animParameter_Title, animParameter_Value);
        }

    }



}
