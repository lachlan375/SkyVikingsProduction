using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class endofDayM : MonoBehaviour {
    public Text  quetSlots;
    public QuestManager quest;
     public Text gold;
    // Use this for initialization
    
	void Start()
	{
		quest = GameObject.FindGameObjectWithTag ("GameController").GetComponent<QuestManager> ();
	}

	void OnEnable()
    {
        int Exp = 0;
        int Gold = 0;
        if(quest.CompletQestList.Count == 0)
        {
            quetSlots.text = "no quests coplet ";
        }
         for(int i = 0;i< 20; i++)
        {
            
             if(i< quest.CompletQestList.Count)
            {
                Exp = quest.CompletQestList[i].ExpReward * quest.CompletQestList[i].TheCargo.Count;
                quetSlots.text += quest.CompletQestList[i].QuestName+"  Exp:"+quest.CompletQestList[i].ExpReward+ "\n";
                Gold += 5;
                Exp += quest.CompletQestList[i].ExpReward;
             }
             
        }
        gold.text ="gold:" + Gold +"  Exp"+Exp;

     }

    void Update ()
    {
    }
}
