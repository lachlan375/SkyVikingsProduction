using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BoatAI : MonoBehaviour
{
    public bool Alert;
    public bool ReachedDesnation;
    public NavMeshAgent BoatNavMesh;
    public hitBox HitBox;
    public Transform Player;
    public int TheTargetID;
    public float StopingDisteance;
    public Transform cannon;
}
