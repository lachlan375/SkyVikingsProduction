using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theShip : MonoBehaviour {

    
   
    public QuestUI theQuest; 
    [Header("The boat")]
    [Tooltip("its the deck of the boat were the objects will sit")]
    public Transform shipsDeack;
    [Tooltip("this is so the ships cargo will move with the ship")]
    public GameObject CargoHold;
    public Transform[] Cargoslots;
    public List<CargoInformation> Thecargo = new List<CargoInformation>();
    [Header("shiping")]
    public bool fanncyShiping;
    public float time;
    public bool yes;
    public int cargoDeliverd;
    public MovementInputController movementController;
    public QuestManager questM;
    [Header("keeps track of the caargo on the ship and here its loaded")]
    public int cargoCounter;
	void Start () {
        

		movementController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MovementInputController>();
    }

    // Update is called once per frame
    void Update () {

    }

    public void loadTheboat()
    {
        //var s2 = gameObject.Ge
       // movementController.MovementLock(true);
        Debug.Log(Cargoslots.Length);
 

        for (int i =cargoCounter; i< Cargoslots.Length; i++)
        {
          if(questM.CurrentQestsList[i].loaded == false)
            {
                var Abox = Instantiate(questM.CurrentQestsList[i].cargo, new Vector3(Cargoslots[i].transform.position.x, shipsDeack.transform.position.y, Cargoslots[i].transform.position.z), Quaternion.identity);
                Abox.transform.parent = CargoHold.transform;
                Thecargo.Add(Abox.GetComponent<CargoInformation>());
                questM.CurrentQestsList[i].loaded = true;
                cargoCounter++;
            }

        }
		movementController.MovementLock(false);




    }
    public void reportcargo( string desnation)
    {
        for(int i = 0; i< Thecargo.Count; i++)
        {
            if(desnation == Thecargo[i].CargoDesnation)
            {
                Debug.Log("i was delverd");
                Thecargo[i].destoyself();
                Thecargo.Remove(Thecargo[i]);
                i -= 1;
                cargoCounter -= 1;
            }
        }
  

    }

    public void removeCargo()
    {
        if (questM.CurrentQestsList.Count == 1)
        {
            questM.CurrentQestsList[0].cargo.GetComponent<CargoInformation>().steallcargo();
        }
        bool foundcaro = false;
        CargoVaule thevaule = CargoVaule.Rare;
        int cargoCouter = 0;
        if (questM.CurrentQestsList.Count > 1)
        {
            while (foundcaro == false)
            {
                if (questM.CurrentQestsList[0].vaule == thevaule)
                {
                    questM.CurrentQestsList[cargoCouter].cargo.GetComponent<CargoInformation>().steallcargo();
                    foundcaro = true;
                }
                else
                {
                    cargoCouter++;
                    if (cargoCouter > questM.CurrentQestsList.Count - 1)
                    {
                        if (thevaule == CargoVaule.Rare)
                        {
                            thevaule = CargoVaule.Uncommon;
                        }
                        if (thevaule == CargoVaule.Uncommon)
                        {
                            thevaule = CargoVaule.Common;
                        }
                        cargoCouter = 0;
                    }
                }

            }

        }


    }
}
