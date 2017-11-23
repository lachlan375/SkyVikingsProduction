using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class compass : MonoBehaviour {
public Vector3 northDirection;
    public Transform player;
    public RectTransform NorthLayer;
    // Use this for initialization
    void Start () {
        Debug.Log(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        northDirection.z = player.eulerAngles.y;
        NorthLayer.localEulerAngles = northDirection;
    }
 
   
}
