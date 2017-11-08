using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTimeScale : MonoBehaviour {

    protected MeshRenderer Renderer;

	// Use this for initialization
	void Start () {
        Renderer = GetComponent<MeshRenderer>();
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Renderer.material.SetFloat("_realtime", Time.realtimeSinceStartup);
        Debug.Log("Timescale: " + Time.timeScale);
	}
}
