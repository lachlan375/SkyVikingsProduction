using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAI : BoatAI
{

    public Transform pathholder;
    public NavMeshAgent BoatNavMesh;
    //  public hitBox HitBox;
    public List<Transform> thePath = new List<Transform>();
    public float waitTime;
    public float TurnSpeed;
    public bool playerInrage;
    public bool stop;
    public Vector3 faceingPonit;
    public int newID;

    // Use this for initialization
    void Start()
    {

        Debug.Log(pathholder.childCount);
        for (int i = 0; i < pathholder.childCount; i++)
        {
            thePath.Add(pathholder.GetChild(i).gameObject.transform);
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 startPositoin = pathholder.GetChild(0).position;
        Vector3 Lastposition = startPositoin;
        foreach (Transform waypoint in pathholder)
        {
            Gizmos.DrawSphere(waypoint.position, 0.3f);
            Gizmos.DrawLine(Lastposition, waypoint.position);
            Lastposition = waypoint.position;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Alert == true)
        {


            BoatNavMesh.stoppingDistance = StopingDisteance;
            BoatNavMesh.SetDestination(Player.transform.position);
            if (BoatNavMesh.remainingDistance <= BoatNavMesh.stoppingDistance)
            {
                ReachedDesnation = true;

            }
        }
        if (Alert == false && stop == false)
        {
            BoatNavMesh.SetDestination(thePath[TheTargetID].transform.position);
            if (BoatNavMesh.remainingDistance <= BoatNavMesh.stoppingDistance)
            {
                StartCoroutine(waitforAsecond());
                TheTargetID = (TheTargetID + 1) % thePath.Count;
                faceingPonit = thePath[TheTargetID].transform.position;
                BoatNavMesh.SetDestination(thePath[TheTargetID].transform.position);
            }
        }
        if (playerInrage == false)
        {
            Alert = false;     
        }
    }
    IEnumerator waitforAsecond()
    {
        stop = true;
        yield return new WaitForSeconds(waitTime);
        stop = false;
        Debug.Log("go");
    }
}


    

