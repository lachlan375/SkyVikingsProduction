﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rowing : MonoBehaviour {
    [Tooltip("if this is on this will contol the boats speed only have one on at a time")]
    public bool headRower;
    public playerStats stats;
    public ShipStats ship;

    
    public MovementSVVertical moveVertRef;
    public MovementInputController moveControlRef;


    [Tooltip("it needs more work but its half the speed of rowing power")]
    public float velocity;
    public bool isRowing;
    public bool slow;
    public float force;
    public Animator rowerAnimPort;
	public Animator rowerAnimSB;
    public float time;
    public float MinSpeed;
    public bool AnkerDOwn;

	public float currentSpeed;

    // Use this for initialization
    void Start () {
        //velocity = 1000.0f;

		rowerAnimPort = gameObject.GetComponent<Animator> ();
		rowerAnimSB = gameObject.GetComponent<Animator> ();

     }



	// Update is called once per frame
	void Update ()
	{
		//Editing CHECK Just a check to see if function is ENABLED

			rowerAnimPort.SetBool ("isRowing", "isRowingPaused", moveVertRef.movingCheck, moveVertRef.row);
			rowerAnimSB.SetBool ("isRowing", moveVertRef.movingCheck);

			if (moveVertRef.movingCheck == true)
			{
				MinSpeed = moveVertRef.speedCurrentVal;
			}
			else
			{
				MinSpeed = 0;
			}
			
			if (moveVertRef.speedCurrentVal != 0) {

                if (!moveVertRef.rowingPausedCheck)
                    {
                    
                        if (slow == false) {
                            StartCoroutine(speedAcceleration());
                            Debug.Log("speed coroutine started");
                        }
                        else if (slow == true)
                        {
                            StartCoroutine(speedDecay());
                        }

                    }
                else
                {
                    StartCoroutine(speedPause());
                }
			}

			//rb.AddForce (transform.forward * speedVarArray[currentSpeedInt];

	}


	/*public void speedDecay()
	{

		if (moveVertRef.rowingCurrentVal >= MinSpeed)
		{
			moveVertRef.rowingCurrentVal -= velocity;
		}

	}*/

	IEnumerator speedDecay()
	{
		

		while (slow == true)
		{
			
			moveVertRef.rowingCurrentVal -= velocity;


			yield return new WaitForSeconds(time);
		}



	}

	IEnumerator speedAcceleration()
	{


		while (slow == false)
		{

			moveVertRef.rowingCurrentVal += moveVertRef.rowingSpeedArray[moveVertRef.currentSpeedInt];


			yield return new WaitForSeconds(time);
		}



	}

    IEnumerator speedPause()
    {
        while (moveVertRef.rowingPausedCheck)
        {
            moveVertRef.rowingCurrentVal -= velocity;
            yield return new WaitForSeconds(time);
        }
    }

    /*public void speedAcceleration()
	{

			if (moveVertRef.rowingCurrentVal > moveVertRef.rowingSpeedMax)
			{
				moveVertRef.rowingCurrentVal = moveVertRef.rowingSpeedMax;
				Debug.Log ("Speed to MAX");
			}
			else
			{
			//moveVertRef.rowingCurrentVal += moveVertRef.rowingPower;
			moveVertRef.rowingCurrentVal = moveVertRef.rowingSpeedArray[moveVertRef.currentSpeedInt];
			}

	}*/

    /*
	//REFERENCE FOR Priorr version setup
	//Mix of my code and Lucy's

	// Update is called once per frame
	void Update () {

        //Editing CHECK Just a check to see if function is ENABLED
        if (AnkerDOwn == false)
        {
            rowerAnim.SetBool("isRowing", moveVertRef.movingCheck);
                        
            if (moveVertRef.movingCheck == true)
            {
                MinSpeed = moveVertRef.speedCurrentVal;
            }
            else
            {
                MinSpeed = 0;
            }

            if (moveVertRef.speedCurrentVal != 0 && slow == false)
                {
                //StartCoroutine(speed());
                Debug.Log("speed coroutine started");
                }
           }
        //rb.AddForce (transform.forward * speedVarArray[currentSpeedInt];
    }
  
	//LUCY's Original Code
    IEnumerator speed()
    {

        
        while (rowingControlRef.rowingSpeedCurrent >= MinSpeed)
            {
                slow = true;
            rowingControlRef.rowingSpeedCurrent -= velocity;
                yield return new WaitForSeconds(time);
            }

            if (rowingControlRef.rowingSpeedCurrent <= 0)
            {
            rowingControlRef.rowingSpeedCurrent = MinSpeed;
            }
            slow = false;
        
    }

    public void rowing()
    {
        if (headRower == true)
        {
            if (slow == false)
            {
                StartCoroutine(speed());
            }
            if (rowingControlRef.rowingSpeedCurrent >= ship.maxSpeed)
            {
                rowingControlRef.rowingSpeedCurrent = ship.rowingPower;
            }
            else
            {
                rowingControlRef.rowingSpeedCurrent += ship.rowingPower;
            }
        }
	}*/
}