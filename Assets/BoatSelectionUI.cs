using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSelectionUI : MonoBehaviour {
    public int boatSelectedInt;

    Animator animator;
    Animation animClock;
    Animation anticlockAnim;

    Animation currAnim;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            float startTime = boatSelectedInt * 0.2f;
            animator.enabled = true;
            animator.Play("HQBoatSelection", -1, startTime);
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            float startTime = boatSelectedInt * 0.2f;
            animator.enabled = true;
            animator.Play("HQBoatSelectionAnti", -1, startTime);
        }
	}

    public void setBoat1()
    {
        AnimSet(0);
    }

    public void setBoat2()
    {
        AnimSet(1);
    }

    public void setBoat3()
    {
        AnimSet(2);
    }

    public void setBoat4()
    {
        AnimSet(3);
    }

    public void setBoat5()
    {
        AnimSet(4);
    }

    void AnimSet(int currentInt)
    {
        if (boatSelectedInt == currentInt)
            return;

        boatSelectedInt = currentInt;
        animator.SetInteger("currentBoatInt", boatSelectedInt);

        // stop the animations form playing ?
        animator.enabled = false; 
    }

    void animStop()
    {
        
    }
}
