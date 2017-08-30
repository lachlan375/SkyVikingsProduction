using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum QuestProgress { NotAvailable, Available, Accepted, Done }

public class QuestManager : MonoBehaviour {
    [Header("Quests information")]
    [Tooltip("finshed Quest list")]
    public List<Quest> CompletQestList = new List<Quest>();
    [Tooltip("Current Quest list")]
    public List<Quest> CurrentQestsList = new List<Quest>();
    ///[Header("Quest UI")]
   // [Tooltip("finshed Quests")]
   // public QuestUI QestComplet;

   

    public void completQests(string Location)
    {

 for(int i = 0; i<CurrentQestsList.Count; i++)
        {
        if(CurrentQestsList[i].QueststLocation == Location)
            {
                Debug.Log("win");
               /// CurrentQestsList[i].Progress = QuestProgress.Done;
               /// CompletQestList.Add(CurrentQestsList[i]);
           //     CurrentQestsList.Remove(CurrentQestsList[i]);
          //      QestComplet.turnon(Location);
             }
        }
        
    }

    

}
