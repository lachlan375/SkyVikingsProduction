using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour {
    public float speed;
    private float sensitivity;
    float RotationY;
    float RotationX;



    // Use this for initialization
    void Start() {



    }

    void FixedUpdate()
    {


        RotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        Debug.Log("Camera Y is" + RotationY);
        Debug.Log("Camera X is" + RotationX);

        RotationX = transform.localEulerAngles.x - Input.GetAxis("Mouse Y")* sensitivity;
        ///     gameObject.transform.localEulerAngles = new Vector3(RotationX, RotationY, 0);
        gameObject.transform.localEulerAngles = new Vector3(RotationX, RotationY, 0);

        transform.position += transform.forward * speed * Time.deltaTime;




    }

}