using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowingSV : MonoBehaviour {
    [Tooltip("if this is on this will contol the boats speed only have one on at a time")]
    public bool headRower;
    private float minspeed = 1;
    public playerStats stats;
    public ShipStats ship;

	public MovementSVVertical moveVertRef;
    //public moveMent row;

    [Tooltip("it needs more work but its half the speed of rowing power")]
    public float velocity;
    public bool isRowing;
    public bool slow;
    public float forse;
    [Tooltip("the time it takes to slow down")]
    public float time;
   public Animator rower;


    // Use this for initialization
    void Start () {
      }
/*	
	// Update is called once per frame
	void Update () {

        rower.SetBool("isRowing", moveVertRef.movingCheck);
		if(moveVertRef.movingCheck == true)
        {
            velocity = ship.rowingPower + stats.totealweight / forse;
            if(velocity > ship.rowingPower)
            {
                velocity = ship.rowingPower;
                Debug.Log("to hevy");
            }
        }
    }
    public void rowing ()
    {
        if(headRower == true)
        {
            if (slow == false)
            {
                StartCoroutine(speed());
            }
            if (row.speed >= ship.maxSpeed)
            {
                row.speed += ship.rowingPower;
                
            }
            else
            {
                row.speed = ship.rowingPower;
            }


        }


    }

    IEnumerator speed()
    {
        while (row.speed > minspeed)
        {
            slow = true;
            row.speed -= velocity; 
            yield return new WaitForSeconds(time);
        }
         if(row.speed <= 0)
        {
            row.speed = 1;
        }
        slow = false;
      }*/
    }
