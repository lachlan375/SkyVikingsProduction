using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postMan : MonoBehaviour {
    [HideInInspector]
    public playerStats player;
    public List<CrateInformation> cratesToGaive = new List<CrateInformation>();
    public List<QestLog> QestCard = new List<QestLog>();
    private BoatCargo TheBoat;
    private GameObject boxCargo;
    public bool oneKind;
    private int ThecCargo;
    public float loadingTime;
    public GameObject theLocation;
    public crateValue CargoVaule;
    [HideInInspector]
    public bool loaded;
    public bool timedQest;
    public bool removeTime;
    public float ExtraTime;
    public hitBox hitbox;
    public qestComplet qest;
    [HideInInspector]
    public bool fancyLoad;
    // Use this for initialization
    void Start()
    {

        TheBoat = FindObjectOfType<BoatCargo>();
        player = FindObjectOfType<playerStats>();
        boxCargo = TheBoat.CargoHold;
        if (CargoVaule == crateValue.Rare || CargoVaule == crateValue.Uncommon)
        {
            fancyLoad = true;
        }
        if (CargoVaule == crateValue.Common)
        {
            fancyLoad = false;
        }
    }


    public void GiveItems()
    {
        player.curentQest.Add(QestCard[0]);
        loaded = false;
        for (int cargo = 0; cargo < TheBoat.ShipCargoHold.Length; ++cargo)
        {

            if (oneKind == true)
            {
                var theBox = Instantiate(cratesToGaive[0].TheCrate, TheBoat.ShipCargoHold[cargo].transform.position, transform.rotation);
                theBox.transform.parent = boxCargo.transform;
                theBox.transform.position = new Vector3(TheBoat.ShipCargoHold[cargo].transform.position.x, TheBoat.ShipsDeck.position.y, TheBoat.ShipCargoHold[cargo].transform.position.z);
                TheBoat.information.Add(cratesToGaive[0]);
                TheBoat.boxes.Add(theBox.GetComponent<summonBox>());


            }
            if (oneKind == false && cargo < cratesToGaive.Count)
            {
                var theBox = Instantiate(cratesToGaive[cargo].TheCrate, TheBoat.ShipCargoHold[cargo].transform.position, transform.rotation);
                theBox.transform.parent = boxCargo.transform;
                TheBoat.information.Add(cratesToGaive[cargo]);
                TheBoat.boxes.Add(theBox.GetComponent<summonBox>());
            }

        }
        loaded = true;
        Debug.Log("loaed");
    }
    public void flashyLoad()
    {
        loaded = false;
        TheBoat.fanncyShiping = true;
        ThecCargo = 0;
        TheBoat.time = loadingTime;
        StartCoroutine(Flashy());
    }
    IEnumerator Flashy()
    {
        while (ThecCargo < TheBoat.ShipCargoHold.Length)
        {
            if (oneKind == true)
            {
                var theBox = Instantiate(cratesToGaive[0].TheCrate, TheBoat.ShipCargoHold[ThecCargo].transform.position, transform.rotation);
                theBox.transform.parent = boxCargo.transform;
                TheBoat.information.Add(cratesToGaive[0]);
                TheBoat.boxes.Add(theBox.GetComponent<summonBox>());

            }
            if (oneKind == false && ThecCargo < cratesToGaive.Count)
            {
                var theBox = Instantiate(cratesToGaive[ThecCargo].TheCrate, TheBoat.ShipCargoHold[ThecCargo].transform.position, transform.rotation);
                theBox.transform.parent = boxCargo.transform;
                TheBoat.information.Add(cratesToGaive[ThecCargo]);
                TheBoat.boxes.Add(theBox.GetComponent<summonBox>());
            }
            ThecCargo++;
            yield return new WaitForSeconds(loadingTime);

        }
        loaded = true;
        Debug.Log("loaed");

    }




}
