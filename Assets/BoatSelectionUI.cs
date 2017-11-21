using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSelectionUI : MonoBehaviour {

    public Transform[] boats;
    public int currentIndex;
    public float speed = 90;

	public HQCanvasSetup CanvasSelection;


    void Start()
    {
        // find all child objects
        boats = new Transform[transform.childCount];
        for (int i = 0; i < boats.Length; i++)
        {
            boats[i] = transform.GetChild(i);
            // make them look at the centre
            boats[i].LookAt(transform.position);
        }

        currentIndex = 0;
    }


    void Update()
    {
        // if we press left arrow, move back one in index
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentIndex--;
        }

        // if we press right arrow, move forward one in index
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentIndex++;
        }

        // keep in the valid range
        currentIndex = (currentIndex+ boats.Length) % boats.Length;

        // get our desired angle
        float desiredAngle = -boats[currentIndex].localEulerAngles.y;

        // move towards it
        float angle = transform.eulerAngles.y;
        angle = Mathf.MoveTowardsAngle(angle, desiredAngle, speed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, angle, 0);

		//playerRef = GameObject.FindWithTag ("GameController");
		CanvasSelection.SelectionUpdate(currentIndex);

		//Original getter/setter ref
		//CanvasSelection.HqBoat = currentIndex;
    }


}
