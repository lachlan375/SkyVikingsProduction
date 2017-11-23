using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HQCanvasSetup : MonoBehaviour {

	public int HqBoat { get {return hqBoat;}set { hqBoat = value; }}

	public GameObject playerControllerRef;
	public ShipStats playerShipStats;
	public LevelManagment levelController;
	public playerStats progressStats;

	//UI References
	public GameObject Activate_Button;
	public GameObject Activated_Button;
	public GameObject Purchaseable_Button;
	public GameObject Purchase_Button;
	public GameObject Locked_Image;



	public ShipStatsState currentBoatState;


	private int hqBoat;
	// Use this for initialization
	void Start () {
		playerControllerRef = GameObject.FindGameObjectWithTag ("GameController");
		playerShipStats = playerControllerRef.gameObject.GetComponent<ShipStats> ();

		currentBoatState = playerShipStats.shippingList [HqBoat];
		progressStats = playerControllerRef.gameObject.GetComponent<playerStats> ();

	}




	// Update is called once per frame
	void Update () {
		LockedScreen ();
		ButtonSetup ();

	}


    //Called from Boat Selection Capsule to Set current boat selection

	public void SelectionUpdate(int currentBoat)
	{

		HqBoat = currentBoat;
		currentBoatState = playerShipStats.shippingList [HqBoat];




	}

	void LockedScreen()
	{
		if (levelController.currentlevelInt >= currentBoatState.unlock_level)
		{
			Locked_Image.SetActive (false);
			playerShipStats.shippingList [HqBoat].is_unlocked = true;

		}
		else {
			Locked_Image.SetActive (true);
			playerShipStats.shippingList [HqBoat].is_unlocked = false;
			//currentBoatState.is_unlocked (false);
		}
	}

	void ButtonSetup ()
	{
		if (currentBoatState.is_unlocked == true)
		{
			if (currentBoatState.is_owned == false)
			{
				
				Activate_Button.SetActive (false);

				if (progressStats.gold >= currentBoatState.unlock_cost) {
					Purchase_Button.SetActive (true);
					Purchaseable_Button.SetActive (false);
				} else {
					Purchase_Button.SetActive (false);
					Purchaseable_Button.SetActive (true);
				}

			}

			else
					
			{
				Purchase_Button.SetActive (false);
				if (currentBoatState.is_activated == true) {
					Activated_Button.SetActive (true);
					Activate_Button.SetActive (false);
				}
				else
				{
					Activated_Button.SetActive (false);
					Activate_Button.SetActive (true);
				}
			}
		}
		else
		{
			Purchase_Button.SetActive (false);
			Activate_Button.SetActive (false);
			Activated_Button.SetActive (false);
		}


	}


	public void Button_Activation()
	{
		
		playerShipStats.ResetActivatedShips ();
        Debug.Log("Button Activated");
        playerShipStats.UpdateCurrentShip (HqBoat);
        currentBoatState.is_activated = true;


    }

	public void Button_Purchase()
	{

		playerShipStats.ResetActivatedShips ();
		Debug.Log("Button Activated");
		playerShipStats.UpdateCurrentShip (HqBoat);
		currentBoatState.is_activated = true;


	}
}
