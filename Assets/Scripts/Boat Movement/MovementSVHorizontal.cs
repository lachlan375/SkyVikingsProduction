using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSVHorizontal : MonoBehaviour
{
    //public Quaternion rot;
    public float rotSpeed;
    public float rotSpeedMin;

    public float maxSpeed;

    float rotate;
    float rotation;

    public GameObject boatObject;
    public Rigidbody rb;
    public float amount = 50.0f;


    // Use this for initialization

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotate = Input.GetAxis("Horizontal");

        //rotate = Input.GetAxisRaw("Rotate");
        rotation = rb.rotation.eulerAngles.y;

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

            rb.AddForce(transform.right * amount * rotate);


        }
     }

}
