using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class basicBaot : MonoBehaviour {
    public Transform [] target;
    public NavMeshAgent navM;
    public int theTarget;
    public hitBox alertField;
    // Use this for initialization
    void Start () {
        theTarget = 0;
	}
	
	// Update is called once per frame
	void Update () {
        navM.SetDestination(target[theTarget].transform.position);
        if(alertField.inTheBox == true)
        {
            theTarget = 1;
        }
        if (alertField.inTheBox == false)
        {
            theTarget = 0;
        }
    }
}
