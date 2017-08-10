using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStats : MonoBehaviour
{
    public float MaxHelth;
    [Tooltip("this just Determens  mouse sensativy right now")]
    public float handling;
    [Tooltip("how fast it takes to get to max speed")]
    public float rowingPower;
    public float weight;
    [Tooltip("the speed of the ship be for weight")]
    public float maxSpeed;
    public float minSpeed;
}