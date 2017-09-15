using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSVHorizontal : MonoBehaviour
{
    //public Quaternion rot;
    //public float rotSpeed;
    //public float rotSpeedMin;

    //public float maxSpeed;

    float rotate;
    //float rotation;

    //public GameObject boatObject;
    public Rigidbody rb;


    public int currentSpeedInt;

    //public float amount = 50.0f;
    public float[] amount = new float[4];


    

    [Tooltip("For more natural turning, force will be applied this distance forward from the center of mass.")]
    public float turnForceOffset;


    // Use this for initialization

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotate = Input.GetAxis("Horizontal");

        
        if (rotate != 0)
        {

            //float dir = Mathf.Sign(rotate);
            //float inputRot = Mathf.Abs(rotate);

            //if (rotate == 0)
            //{
            //    rotation += ((inputRot * rotSpeed) * Time.deltaTime) * dir;
            //    //rb.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            //}
            //else
            //{
            //    /*rotation += ((inputRot * rotSpeedMin) * Time.deltaTime) * dir;

            //    rb.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);*/

            //    float h = rotate * amount;
            //    rb.AddTorque(transform.right * h);


            //}
            //TEMP REMOVED BY ADAM
            // rb.AddForce(transform.right * amount * rotate);
            //TEMP REMOVED BY ADAM
            Vector3 forceAddPos = transform.position + rb.centerOfMass + (transform.forward * turnForceOffset);
            rb.AddForceAtPosition(transform.right * amount[currentSpeedInt] * rotate, forceAddPos);
        }
    }

    public void MoveHorizUpdate(int speedIntRef)
    {
        currentSpeedInt = speedIntRef;
    }



}
