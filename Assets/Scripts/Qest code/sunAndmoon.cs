using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunAndmoon : MonoBehaviour {
    static bool TimeStop;
    public float speed;
    private float [] location = new float[3];
 
 	// Use this for initialization
	void Start () {
        location[0] = gameObject.transform.position.x;
        location[1] = gameObject.transform.position.y;
        location[2] = gameObject.transform.position.z;


    }

    // Update is called once per frame
    void Update () {
		if(TimeStop == false)
        {
            transform.RotateAround(Vector3.zero, Vector3.right, speed * Time.deltaTime);
            transform.LookAt(Vector3.zero);
        }
        if(TimeStop == true)
        {
            gameObject.transform.position = new Vector3(location[0], location[1], location[2]);

        }
    }
    public void andStop()
    {
        TimeStop = !TimeStop;
    }
}
