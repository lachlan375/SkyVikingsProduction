using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class basicBaot : BoatAI {
    public Transform [] target;
    public NavMeshAgent BoatNavMesh;
    public hitBox HitBox;
    public hitBox Playerinrage;
    public Transform cannon;
    public 

    // Use this for initialization
    void Start () {
        TheTargetID = 0;
	}

    // Update is called once per frame
    void Update()
    {
        if(ReachedDesnation == false)
        {
        BoatNavMesh.SetDestination(target[TheTargetID].transform.position);

        }
        if (Alert == false)
        {
            if (HitBox.inTheBox == true)
            {
                TheTargetID = 1;
                BoatNavMesh.stoppingDistance = StopingDisteance;
                Alert = true;

            }
            if (HitBox.inTheBox == false)
            {
                TheTargetID = 0;
                BoatNavMesh.stoppingDistance = 0;
                cannon.transform.transform.LookAt(target[0]);
            }

        }
        if (Alert == true)
        {
            if (BoatNavMesh.remainingDistance <= BoatNavMesh.stoppingDistance)
            {
                ReachedDesnation = true;
                Debug.Log("hit");
            }

        }
        if(Playerinrage.inTheBox == false)
        {

            Alert = false;
        }
    }
    public void restart()
    {
        Debug.Log("finshed");
        Alert = false;
        HitBox.inTheBox = false;
        ReachedDesnation = false;

    }


}
