using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystemProto1 : MonoBehaviour {


	public float speedThruster;
	public float speedRThruster;
	public float sideBooster;
	public float tilt;

	public GameObject partThruster;
    public GameObject partRThruster;
    public GameObject partLeftBooster;
    public GameObject partRightBooster;
	public GameObject partLeftRotate;
	public GameObject partRightRotate;

 


    //not sure what below is used for???
    public Quaternion rot;
	public float rotSpeed;
    public float rotSpeedMin;

    public float maxSpeed;

    float rotate;
    float rotation;

    float moveHorizontal;
    float moveVertical;

    //attempt to add physics to ship object
    public Rigidbody rb;
	// Use this for initialization


	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		rotate = Input.GetAxisRaw("Rotate");
		rotation = rb.rotation.eulerAngles.y;

		if (rotate != 0)
		{
            
            float dir = Mathf.Sign(rotate);
			float inputRot = Mathf.Abs(rotate);

            if (moveVertical == 0)
            {
                rotation += ((inputRot * rotSpeed) * Time.deltaTime) * dir;
                rb.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            } else
            {
                rotation += ((inputRot * rotSpeedMin) * Time.deltaTime) * dir;
                rb.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            }

			Debug.Log("RIGHT rotate is " + rotation + "degrees");

			if (dir == 1) {

                partRightRotate.SetActive (true);

            } else if (dir == -1) {

                partLeftRotate.SetActive (true);
			} 
		}
		else
		{

            partLeftRotate.SetActive (false);
			partRightRotate.SetActive (false);

		}

	}


	void FixedUpdate()
	{





        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);





        //Checking to see IF GOING FORWARD
        if (moveVertical > 0.1)
		{
            partThruster.SetActive(true);
			//GetComponent<Rigidbody>().AddForce = movement * speedThruster;
			rb.AddForce(transform.forward * speedThruster);
   		}

		//Checking to see IF GOING BACKWARD
		else if (moveVertical <= -0.1)
		{
			partRThruster.SetActive(true);
			//GetComponent<Rigidbody>().velocity = movement * speedRThruster;
			rb.AddForce(transform.forward * -speedRThruster);
		}

		//if NEITHER is the case then deactivate thruster FX
		else
		{
			partThruster.SetActive(false);
			partRThruster.SetActive(false);
		}


		//Checking to see IF GOING LEFT but not if thruster is ALSO being used
		if (moveHorizontal >= 0.1 /*&& moveVertical == 0*/)
		{

			rb.AddForce(transform.right * sideBooster);
			//GetComponent<Rigidbody>().velocity = movement * sideBooster;
			partLeftBooster.SetActive(true);
			partRightBooster.SetActive(false);
            
		}

		//Checking to see IF GOING RIGHT but not if thruster is ALSO being used
		else if (moveHorizontal <= -0.1 /*&& moveVertical == 0*/)
		{
			rb.AddForce(transform.right * -sideBooster);


			//GetComponent<Rigidbody>().velocity = movement * sideBooster;
			partRightBooster.SetActive(true);
			partLeftBooster.SetActive(false);
		}
		//if NEITHER is the case then deactivate thruster FX
		else
		{
			partLeftBooster.SetActive(false);
			partRightBooster.SetActive(false);

		}

        //WITH tilt added
		//rb.rotation = Quaternion.Euler(0.0f, rotation, GetComponent<Rigidbody>().velocity.x * -tilt);
        rb.rotation = Quaternion.Euler(0.0f, rotation, GetComponent<Rigidbody>().velocity.x * -tilt);
    }
}