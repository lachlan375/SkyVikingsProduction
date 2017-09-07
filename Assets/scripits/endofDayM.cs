using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class endofDayM : MonoBehaviour {
    public Text [] quetSlots;
    public QuestManager quest;
     public Text gold;
    // Use this for initialization
    void OnEnable()
    {
        int Gold = 0;

         for(int i = 0;i< quetSlots.Length; i++)
        {
            
            quetSlots[i].text = "";
            if(i< quest.CompletQestList.Count)
            {
                quetSlots[i].text = quest.CompletQestList[i].QuestName;
                Gold += 1;
             }
             
        }
        gold.text ="gold:" + Gold;

     }

    void Update ()
    {
    }
}
