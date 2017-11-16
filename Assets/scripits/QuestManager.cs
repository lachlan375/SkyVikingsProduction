using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum QuestProgress { NotAvailable, Available, Accepted, Done,failed }

public class QuestManager : MonoBehaviour {
    [Header("Quests information")]
    [Tooltip("finshed Quest list")]
    public List<Quest> CompletQestList = new List<Quest>();
    [Tooltip("Current Quest list")]
    public List<Quest> CurrentQestsList = new List<Quest>();
    [Header("Quest UI")]
    [Tooltip("finshed Quests")]
    public QuestUI QestComplet;
    public theShip ship;
    public bool TheQuestComplet;
    public int maxCargo;
    public PlaySatSheat cargosats;
    void Start()
    {
        Debug.Log(gameObject); 
        cargosats = FindObjectOfType<PlaySatSheat>();
        foreach (StatsBace item in cargosats.TheStats)
        {

            if (item.StatName == "maxCargo")
            {
                maxCargo = item.statInt;
            }
        }

    }
    public void completQests(string Location)
    {
        Debug.Log(gameObject);
 for(int i = 0; i<CurrentQestsList.Count; i++)
        {
        if(CurrentQestsList[i].qestLocationGameObject.name == Location)
            {
                Debug.Log("win");
                Debug.Log("Object loaded");

                ship.reportcargo(Location);
                if(CurrentQestsList[i].cargo.GetComponent<CargoInformation>().CargoAmount > 1)
                {
                CurrentQestsList[i].Progress = QuestProgress.Done;
                    CurrentQestsList[i].ExpTogive(ship.cargoDeliverd);
                }
                else
                {
                    Debug.Log("fail");
                    CurrentQestsList[i].Progress = QuestProgress.failed;
                }
                CompletQestList.Add(CurrentQestsList[i]);
                CurrentQestsList.Remove(CurrentQestsList[i]);
                QestComplet.turnon(Location);
                TheQuestComplet = true;
              }
        }
        
    }


    

}
