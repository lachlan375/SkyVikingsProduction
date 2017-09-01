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
	void Start () {
 

    }

    // Update is called once per frame
    void Update () {

    }

    public void loadTheboat(int TownID,int QuestID)
    {
        Debug.Log(Cargoslots.Length);
        for(int i =0; i< Cargoslots.Length; i++)
        {
            var Abox = Instantiate(theQuest.Quests[TownID].AvailableQuests[QuestID].TheCargo[0].theCargo, new Vector3(Cargoslots[i].transform.position.x, shipsDeack.transform.position.y, Cargoslots[i].transform.position.z), Quaternion.identity);
            Abox.transform.parent = CargoHold.transform;
            Thecargo.Add(Abox);
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
}
