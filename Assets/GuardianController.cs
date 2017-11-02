using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianController : MonoBehaviour {
	public GameObject canvasRef;
	public bool guardiansMode_Unlocked;

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        if (guardiansMode_Unlocked)
        {

        }
    }

	public void HighStakesAccepted()
	{
		guardiansMode_Unlocked = true;
        CanvasDeativation();

    }

	public void HighStakesDeclined()
	{
		guardiansMode_Unlocked = false;
        CanvasDeativation();

    }

    public void CanvasDeativation()
    {
        canvasRef.SetActive(false);
    }


}
