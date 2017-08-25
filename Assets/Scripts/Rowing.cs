using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rowing : MonoBehaviour {
    /*[Tooltip("if this is on this will contol the boats speed only have one on at a time")]
    public bool headRower;
    public playerStats stats;
    public ShipStats ship;
    public moveMent row;
    [Tooltip("it needs more work but its half the speed of rowing power")]
    public float velocity;
    public bool isRowing;
    public bool slow;
    public float forse;
     public Animator rower;
    public float time;
    private float MinSpeed;
    public bool AnkerDOwn;

    // Use this for initialization
    void Start () {
        /// velocity = stats.totealweight;
        velocity = ship.rowingPower/forse;
     }
	

    
    //* Lucy's original script
	// Update is called once per frame
	void Update () {
        if(AnkerDOwn == false)
        {
            rower.SetBool("isRowing", row.moveing);
            if (row.moveing == true)
            {
                MinSpeed = ship.minSpeed;
            }
            if (row.moveing == false)
            {
                MinSpeed = 0;
                if (row.speed != 0 && slow == false)
                {
                    //  StartCoroutine(speed());
                }
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
                row.speed = ship.rowingPower;
 
            }
            else
            {
            row.speed += ship.rowingPower;        
            }

          }


    }
 

    IEnumerator speed()
    {
      
            while (row.speed >= MinSpeed)
            {
                slow = true;
                row.speed -= velocity;
                yield return new WaitForSeconds(time);
            }

            if (row.speed <= 0)
            {
                row.speed = MinSpeed;
            }
            slow = false;
       
        
    }*/

    [Tooltip("if this is on this will contol the boats speed only have one on at a time")]
    public bool headRower;
    public playerStats stats;
    public ShipStats ship;
    public MovementSVVertical movementVertical;
    [Tooltip("it needs more work but its half the speed of rowing power")]
    public float velocity;
    public bool isRowing;
    public bool slow;
    public float forse;
     public Animator rowerAnim;
    public float time;
    private float MinSpeed;
    public bool AnkerDOwn;

    // Use this for initialization
    void Start () {
        /// velocity = stats.totealweight;
     //   velocity = ship.rowingPower/forse;
     }
	

    /*
    //* Lucy's original script
	// Update is called once per frame
	void Update () {
        if(AnkerDOwn == false)
        {
            rowerAnim.SetBool("isRowing", movementVertical.movingCheck);
            if (movementVertical.movingCheck == true)
            {
                MinSpeed = ship.minSpeed;
            }
            if (movementVertical.movingCheck == false)
            {
                MinSpeed = 0;
                if (movementVertical.speed != 0 && slow == false)
                {
                    StartCoroutine(speed());
                }
            }

        }
    }
     
    IEnumerator speed()
    {
      
            while (movementVertical.speed >= MinSpeed)
            {
                slow = true;
            movementVertical.speed -= velocity;
                yield return new WaitForSeconds(time);
            }

            if (movementVertical.speed <= 0)
            {
            movementVertical.speed = MinSpeed;
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
            if (movementVertical.speed >= ship.maxSpeed)
            {
                movementVertical.speed = ship.rowingPower;

            }
            else
            {
                movementVertical.speed += ship.rowingPower;
            }

        }


    }*/


}
