using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rowing : MonoBehaviour {
    [Tooltip("if this is on this will contol the boats speed only have one on at a time")]
    public bool headRower;
    public playerStats stats;
    public ShipStats ship;

    
    public MovementSVVertical moveVertRef;
    public MovementInputController moveControlRef;
    public RowerController rowingControlRef;

    [Tooltip("it needs more work but its half the speed of rowing power")]
    public float velocity;
    public bool isRowing;
    public bool slow;
    public float force;
     public Animator rowerAnim;
    public float time;
    public float MinSpeed;
    public bool AnkerDOwn;

    // Use this for initialization
    void Start () {
        velocity = 1000.0f;

        rowingControlRef = gameObject.GetComponent<RowerController>();
     }
	

    
    
	// Update is called once per frame
	void Update () {

        //Editing CHECK Just a check to see if function is ENABLED
        if (AnkerDOwn == false)
        {
            //rowerAnim.SetBool("isRowing", moveVertRef.movingCheck);
                        
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
    
    /*IEnumerator speed()
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
        }*/
}