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
    public bool is_rotating;

    public bool tiltFuction;
    public float tilt;


    float rotation;
    public Quaternion originalRotation;
    public Quaternion toTransform;
    public float tiltRetRotation = 1.0f;

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
        originalRotation = transform.rotation;
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

            if (currentSpeedInt != 0)
            {
                if (tiltFuction)
                {
                    TiltFunctionality();
                }
            }

            is_rotating = true;

            Vector3 forceAddPos = transform.position + rb.centerOfMass + (transform.forward * turnForceOffset);
            rb.AddForceAtPosition(transform.right * amount[currentSpeedInt] * rotate, forceAddPos);
            
        }
        else
        {
            if (is_rotating)
            {
                //toTransform.rotation
                TiltEnding();
                is_rotating = false;
            }
        }
    }

    public void MoveHorizUpdate(int speedIntRef)
    {
        currentSpeedInt = speedIntRef;

    }

    public void TiltFunctionality()
    {
        //Physics Rotation
        //TEMP Test to see if tilt functionality can be added
        rotation = rb.rotation.eulerAngles.y;
        rb.rotation = Quaternion.Euler(0.0f, rotation, GetComponent<Rigidbody>().velocity.x * -tilt);
        //END of Physics Rotation

        //Transform Rotation

    }

    public void TiltEnding()
    {
        //Physics Rotation
        //TEMP Test to see if tilt functionality can be added

        //rb.rotation = Quaternion.Euler(0, rotation, 0);

        //END of Physics Rotation

        originalRotation.y = transform.rotation.y;
        originalRotation.x = 0;
        originalRotation.z = 0;

        //Transform Rotation
        rb.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.time * tiltRetRotation);

    }


}
