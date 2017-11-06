using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInputController : MonoBehaviour {


    public Rigidbody rb;

    public MovementHorizontal horizRef;
    public MovementSVVertical vertRef;
    public RowerController rowRef;


    [Header("Movement Input")]
    public float moveVertical;
    public float moveHorizontal;
    public float movePaused;
    [Tooltip("Time allowed for ship activation/deactivation")]
    public float time;

    [Header("Ship Speed Settings")]
    public int currentSpeedInt; //ref for Current SpeedVar array
    public int totalSpeedInt;	//TOTAL length counter SpeedVar array

    public bool is_rowingPaused;
    public bool is_moving;
	public bool is_reversing;
    


    // Use this for initialization
    void Start () {

		/*
		 * //rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();

		rb = gameObject.GetComponentInChildren<Rigidbody>();

		horizRef = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementHorizontal>();

		//vertRef = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementSVVertical>();
        //rowRef = GetComponent<RowerController>();
		*/


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

       /* if (Input.GetKeyDown("VerticalCancel"))
        {
            movePaused = Input.GetAxis("VerticalCancel");
            VertCancelationCheck(movePaused);
            is_rowingPaused = true;

        }
        else { is_rowingPaused = false; }*/

        vertRef.MoveVertUpdate(currentSpeedInt, is_rowingPaused, is_moving, is_reversing);
		horizRef.MoveHorizUpdate (currentSpeedInt);
    }

    public void MovementCheck(float movementInput)
    {
        if (movementInput > 0)
        {
            //CHECK to see if PLAYER is moving under the Speed limit
            if (currentSpeedInt < totalSpeedInt)
            {
                Debug.Log("Current Speed increased!!!");
                currentSpeedInt++;

                //CHECK to see if PLAYER is moving
                if (currentSpeedInt != 1)
                {
                    is_moving = true;
					is_reversing = false;
                }

                else
                {
                    is_moving = false;
					is_reversing = false;

                }
            }
            else
            {
                Debug.Log("Speed limit Reached!!!");
                currentSpeedInt = totalSpeedInt;
            }
        }
        //CHECK to see INPUT (Vertical Movement) is going backwards
        else if (moveVertical < 0)
        {
            if (currentSpeedInt > 0)
            {
                Debug.Log("Current Speed slowed down!!!");

                currentSpeedInt--;
				if (currentSpeedInt == 1) {
					Debug.Log ("Vessel is now stationary!!!");
					is_moving = false;
					is_reversing = false;
				} else
				{
					is_moving = true;
					is_reversing = true;
				}
            }
            else
            {
                Debug.Log("Speed levels at Minimum acceptable level");
            }
        }
    // Call functions from Vert/Horizontal/Rowing Movement scripts AND pass on the current speed INT coutnerz
		/*vertRef.MoveVertUpdate(currentSpeedInt, is_moving);
        
		horizRef.MoveHorizUpdate (currentSpeedInt);
        //rowRef.RowStatUpdate(currentSpeedInt);*/
    }

    public void VertCancelationCheck(float vertCanceled)
    {

    }

    /// <summary>
    /// Called when player movement options need to be Activated/Deactivated
    /// </summary>
    /// <param name="inputMovementAllowed"></param>

    //Method that is called to CHECK if player object should be paused, or restarted
    public void MovementLock(bool inputMovementAllowed)
    {
        if (!inputMovementAllowed)
        {
            Debug.Log("TURN OFF Movement Controller");
            //horizRef.enabled = false;
            vertRef.enabled = false; 
        }
        else
        {
            StartCoroutine(MovementPause());
        }
    }

    //Coroutine function called from MovementActivationCall.
    //Resets player movement, but only after a pause.
    IEnumerator MovementPause()
    {

        Debug.Log("TURN ON Movement Controller REQUESTED");
        yield return new WaitForSeconds(3.0f);
        Debug.Log("TURN ON Movement Controller ACTIVATED");
        
        //vertRef.MoveVertUpdate(1, false ,false);
		MovementReset();
        vertRef.enabled = true;
    }


	//Function to Reset movement of ship to Zero
    public void MovementReset()
    {
		currentSpeedInt = 1;
		vertRef.MoveVertUpdate(currentSpeedInt, false, false);
    }
    

}
