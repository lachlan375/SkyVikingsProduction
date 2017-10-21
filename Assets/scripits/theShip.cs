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
    public List<GameObject> Thecargo = new List<GameObject>();
    [Header("shiping")]
    public bool fanncyShiping;
    public float time;
    public bool yes;
    public int cargoDeliverd;
    public MovementInputController movementController;

	void Start () {

        
    }

    // Update is called once per frame
    void Update () {

    }

    public void loadTheboat(int TownID,int QuestID,string QestGIverName)
    {
        //var s2 = gameObject.Ge
        movementController.MovementActivationCall(false);
        Debug.Log(Cargoslots.Length);
        for(int i =0; i< Cargoslots.Length; i++)
        {
            var Abox = Instantiate(theQuest.Quests[TownID].AvailableQuests[QuestID].TheCargo[0].theCargo, new Vector3(Cargoslots[i].transform.position.x, shipsDeack.transform.position.y, Cargoslots[i].transform.position.z), Quaternion.identity);
            Abox.gameObject.name = QestGIverName;
            Abox.transform.parent = CargoHold.transform;
            Thecargo.Add(Abox);
            
        }
        movementController.MovementActivationCall(true);




    }
    public void reportcargo( string gameobjectName)
    {
        cargoDeliverd = 0;
        for(int i = 0; i< Thecargo.Count; i++)
        {
            if(gameobjectName == Thecargo[i].name)
            {
                cargoDeliverd++;
                Debug.Log("i was hit");
                Destroy(Thecargo[i]);
                Thecargo.Remove(Thecargo[i]);
                i -= 1;
            }
        }
  

    }
    public void destoyCargo()
    {
        
        while (Cargoslots.Length >0)
        {
             
            Destroy(Thecargo[0]);
            Thecargo.Remove(Thecargo[0]);
        }
    }
    public void removeCargo(int amountoRemove)
    {
        
            for(int i = 0; i< amountoRemove; i++)
            {
            if (Thecargo.Count > 0)
            {
                Destroy(Thecargo[0]);
        Thecargo.Remove(Thecargo[0]);
            
            }
  
        }
  



    }
}
