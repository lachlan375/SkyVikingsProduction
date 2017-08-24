using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMent : MonoBehaviour {
    public float speed;
     public float rowingSpeed;
    private float Shipweight;
    public float sensativtsy;
    float RotationY;
    float RotationX;
    public ShipStats ship;
    public playerStats stats;
    public bool moveing;
    public bool rowfinshed;
      // Use this for initialization
    void Start () {
        speed = 0.1f;
     }

    // Update is called once per frame
    void Update () {
        #region ship movement

        if (Input.GetKeyDown("space"))
        {
            //    DontShow = false;
            moveing = !moveing;
          
        }
        #endregion

        #region Ship Control

        RotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X")* sensativtsy;
        ////   RotationX= transform.localEulerAngles.x - Input.GetAxis("Mouse Y")* sensativtsy;
        ///     gameObject.transform.localEulerAngles = new Vector3(RotationX, RotationY, 0);
             gameObject.transform.localEulerAngles = new Vector3(RotationX, RotationY, 0);

        transform.position += transform.forward * speed * Time.deltaTime;

        #endregion

    }
  
}
