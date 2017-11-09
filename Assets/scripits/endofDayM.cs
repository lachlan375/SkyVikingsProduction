using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class endofDayM : MonoBehaviour {
    public Text  quetSlots;
    public QuestManager quest;
    public playerStats player;
    public Text gold;
    private int loss;
    public int gains;
    public Text respectText;
    public ObjectPriceList maxCargo;
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
        if(quest.CurrentQestsList.Count >0)
        {
           for(int i = 0; i< quest.CurrentQestsList.Count;i++)
            {
                loss += quest.CurrentQestsList[i].QuestRespect;
            }
        }
         for(int i = 0;i< maxCargo.maxCargo; i++)
        {
            
             if(i< quest.CompletQestList.Count)
            {
                Exp = quest.CompletQestList[i].ExpReward * quest.CompletQestList[i].TheCargo.Count;
                quetSlots.text += quest.CompletQestList[i].QuestName+"  Exp:"+quest.CompletQestList[i].ExpReward+ "\n";
                Gold += 5;
                Exp += quest.CompletQestList[i].ExpReward;
                gains += quest.CompletQestList[i].QuestRespect;

            }

        }
        gold.text ="gold:" + Gold +"  Exp"+Exp;
        respectText.text = "respect :" + "-" + loss + "  " +"+"+gains;
        player.respectScore += gains;
        player.respectScore -= gains;
        if(player.respectScore <0)
        {
            Debug.Log("game over");
        }

    }

    void Update ()
    {
    }
}
