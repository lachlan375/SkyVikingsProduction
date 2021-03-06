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


    public float acceleration = 100;

    // Use this for initialization
    void Start () {
    }

	// Update is called once per frame
	void Update ()
	{
		//Editing CHECK Just a check to see if function is ENABLED

		rowerAnimPort.SetBool ("isRowing", moveVertRef.movingCheck);
        rowerAnimPort.SetFloat("currentSpeed", moveVertRef.currentSpeedInt);
        rowerAnimPort.SetBool ("isReversing", moveVertRef.rowingReversedCheck);

        rowerAnimSB.SetBool ("isRowing", moveVertRef.movingCheck);
        rowerAnimSB.SetFloat("currentSpeed", moveVertRef.currentSpeedInt);
        rowerAnimSB.SetBool("isReversing", moveVertRef.rowingReversedCheck);

        // if we're moving forwards, accelerate when the oars are engaged
        if (moveVertRef.movingCheck)
        {
            if (!slow)
                moveVertRef.rowingCurrentVal += Time.deltaTime * acceleration;
        }
        else if (moveVertRef.rowingReversedCheck)
        {
            if (!slow)
                moveVertRef.rowingCurrentVal -= Time.deltaTime * acceleration *0.5f;
        }
        else // slow down
        {
            moveVertRef.rowingCurrentVal *= 0.99f; // TODO
        }


        /*
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
			}*/

            
	}


	IEnumerator speedDecay()
	{
		while (slow == true)
		{
            if (moveVertRef.rowingCurrentVal > 0)
			    moveVertRef.rowingCurrentVal -= velocity;
            else
                moveVertRef.rowingCurrentVal += velocity;
            yield return new WaitForSeconds(time);
		}
	}

	IEnumerator speedAcceleration()
	{
		while (slow == false)
		{
			moveVertRef.rowingCurrentVal = moveVertRef.rowingSpeedArray[moveVertRef.currentSpeedInt];
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
}