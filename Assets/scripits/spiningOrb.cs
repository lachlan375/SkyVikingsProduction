using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiningOrb : MonoBehaviour {
    public float speed;
    public Transform target;
    // Use this for initialization

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 startPositoin =  transform.position  ;
        Vector3 Lastposition = target.transform.position;
        Gizmos.DrawLine(Lastposition, startPositoin);
        Gizmos.DrawSphere(startPositoin, 0.3f);
        Gizmos.DrawSphere(Lastposition, 0.3f);



    }
    // Update is called once per frame
    void Update ()
    {
        transform.Rotate(0, speed, 0);
    }
}
