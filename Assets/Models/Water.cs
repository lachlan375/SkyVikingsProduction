using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        GetComponent<MeshRenderer>().material.SetTexture("_MaskTex", FindObjectOfType<WaterMask>().maskTexture);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
