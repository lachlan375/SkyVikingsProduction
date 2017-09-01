using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour {
    [Tooltip("you need this for it to work")]
    public Rigidbody FlaotingObject;
    [Header("water physics")]
    public float WaterLevel = 0.0f;
    public float floatThreshold = 2f;
    public float WaterDensity = 0.125f;
    public float DownForce = 4f;
    float ForceFactor;
    Vector3 floatForce;
    // Update is called once per frame
    void FixedUpdate()
    {
        ForceFactor = 1.0f - ((transform.position.y - WaterLevel) / floatThreshold);
        if (ForceFactor > 0.0f)
        {
            floatForce = -Physics.gravity * (ForceFactor - FlaotingObject.velocity.y * WaterDensity);
            floatForce += new Vector3(0.0f, -DownForce, 0.0f);
            FlaotingObject.AddForceAtPosition(floatForce, transform.position);
        }
    } 
}
 