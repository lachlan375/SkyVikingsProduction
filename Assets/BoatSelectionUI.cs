using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSelectionUI : MonoBehaviour {
    public int boatSelectedInt;

    Animator animator;
    Animation animClock;
    Animation anticlockAnim;

    Animation currAnim;
	public Animation anim;

	public bool isunlocked_anim = true;
	public float inputAxis;



	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

        
	}

    // Update is called once per frame
    /*void Update () {
        
		//check to see if input is enable
		////it may still be finishing animation

		if (isunlocked_anim) {

			if (Input.GetKeyDown (KeyCode.RightArrow))
			{
				
				anim["HQBoatSelection"].speed = 1.0f;
				inputAxis = 1;
				float startTime = boatSelectedInt * 0.2f;
				animator.enabled = true;

				animator.Play ("HQBoatSelection", 0, startTime);


				isunlocked_anim = false;
			}

			else if (Input.GetKeyDown (KeyCode.LeftArrow))
			{
				
				anim["HQBoatSelection"].speed = -1.0f;
				inputAxis = -1;
				float startTime = boatSelectedInt * 0.2f;
				animator.enabled = true;

				animator.Play ("HQBoatSelection", 0, startTime);
				isunlocked_anim = false;
			}
				
		}
	}*/

    // Update is called once per frame
    void Update()
    {

        //check to see if input is enable
        ////it may still be finishing animation

        if (isunlocked_anim)
        {

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                inputAxis = 1.0f;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                inputAxis = -1.0f;
            }

            

            //anim["HQBoatSelection"].speed = inputAxis;

            float startTime = boatSelectedInt * 0.2f;
            animator.enabled = true;

            animator.Play("HQBoatSelection", 0, startTime);


            isunlocked_anim = false;
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
		isunlocked_anim = true;
    }

    void animStop()
    {
        
    }
}
