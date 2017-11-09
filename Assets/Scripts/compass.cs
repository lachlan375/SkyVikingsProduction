using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class compass : MonoBehaviour {
public Vector3 northDirection;
    public Transform player;
    public Quaternion missionDirection;
    public RectTransform NorthLayer;
    public RectTransform missionLayer;
    public Transform missionLocation;
    // Use this for initialization
    void Start () {
        Debug.Log(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        changeNorthDirection();
         changemissionDirection();
    }
    public void changeNorthDirection()
    {
        northDirection.z = player.eulerAngles.y;
        NorthLayer.localEulerAngles = northDirection;
        
    }
    public void changemissionDirection()
    {
        Vector3 dir = transform.position - missionLocation.position;
        missionDirection = Quaternion.LookRotation(dir);
        missionDirection.z = -missionDirection.y;
        missionDirection.x = 0;
        missionDirection.y = 0;
        missionLayer.localRotation = missionDirection * Quaternion.Euler(northDirection);
    }
}
