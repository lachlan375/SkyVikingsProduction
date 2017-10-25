using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunAndmoon : MonoBehaviour {
    public bool TimeStop;
    public float speed;
    public GameObject sun;
    public GameObject moon;
    public GameObject endDay;  

 	// Use this for initialization
	void Start () {
 
    }

    // Update is called once per frame
    void Update () {

		if(TimeStop == false)
        {
            sun.transform.LookAt(transform.position);
            moon.transform.LookAt(transform.position);
            transform.Rotate(Vector3.right *speed*Time.deltaTime);
             Vector3 Angles = transform.eulerAngles;
            transform.eulerAngles = Angles;
            if(Angles.x >= 180)
            {
                dayoverScreen();
                Debug.Log("end day");
 
            }
        }

    }
    public void andStop()
    {
        TimeStop = !TimeStop;
    }
    public void dayoverScreen()
    {
        endDay.SetActive(true);
        TimeStop = true;

    }
}
