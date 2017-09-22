using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInputController : MonoBehaviour {

    public Rigidbody rb;

    public MovementSVHorizontal horizRef;
    public MovementSVVertical vertRef;
    public RowerController rowRef;
	public MovementHorizontal moveHoriz;

    [Header("Movement Input")]
    public float moveVertical;
    public float moveHorizontal;

    [Header("Ship Speed Settings")]
    public int currentSpeedInt; //ref for Current SpeedVar array
    public int totalSpeedInt;	//TOTAL length counter SpeedVar array

    public bool is_moving;
    public bool is_idle;

    public 



    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

        moveHoriz = GetComponent<MovementHorizontal>();
        vertRef = GetComponent<MovementSVVertical>();
        rowRef = GetComponent<RowerController>();


        currentSpeedInt = 1;
        totalSpeedInt = vertRef.VertInit();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Vertical"))
        {
            //Debug.Log("Debug log ACTIVATED");
            moveVertical = Input.GetAxis("Vertical");
            MovementCheck(moveVertical);
        }


        if (Input.GetButtonDown("Horizontal"))
        {
            moveHorizontal = Input.GetAxis("Horizontal");
        }

        //rb.AddForce(transform.forward * 1000.0f);
        
    }

    public void MovementCheck(float movementInput)
    {
        if (movementInput > 0)
        {
            if (currentSpeedInt < totalSpeedInt)
            {
                Debug.Log("Current Speed increased!!!");
                currentSpeedInt++;

                //Check to see if boat is stationary
                if (currentSpeedInt != 1)
                {
                    is_moving = true;
                    is_idle = false;
                }

                else
                {
                    is_moving = false;
                    is_idle = true;
                }
            }
            else
            {
                Debug.Log("Speed limit Reached!!!");
                currentSpeedInt = totalSpeedInt;
            }

        }

        //Checking to see IF GOING BACKWARD
        else if (moveVertical < -0)
        {
            if (currentSpeedInt > 0)
            {
                
                Debug.Log("Current Speed slowed down!!!");

                currentSpeedInt--;
                if (currentSpeedInt == 1)
                {
                    Debug.Log("Vessel is now stationary!!!");
                    is_moving = false;
                    is_idle = true;
                }
            }
            else
            {
                Debug.Log("Speed levels at Minimum acceptable level");
                
            }
        }

    // Call functions from Vert/Horizontal/Rowing Movement scripts AND pass on the current speed INT coutnerz
        vertRef.MoveVertUpdate(currentSpeedInt);
        
		moveHoriz.MoveHorizUpdate (currentSpeedInt);
        rowRef.RowStatUpdate(currentSpeedInt);

    }


}
