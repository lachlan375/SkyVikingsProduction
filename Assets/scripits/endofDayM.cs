using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class endofDayM : MonoBehaviour

{
    public Text quetSlots;
    public QuestManager quest;
    public playerStats player;
    public Text gold;
    public int loss;
    public int gains;
    public Text respectText;
    public ObjectPriceList pricelist;
    public GameObject gameover;
    public GameObject newday;
    // Use this for initialization

    void Start()
    {
        quest = FindObjectOfType<QuestManager>();
        player = FindObjectOfType<playerStats>();
    }

    void OnEnable()
    {
        int Exp = 0;
        int Gold = 0;
        int Questvaule = 0;
        if (quest.CompletQestList.Count == 0)
        {
            quetSlots.text = "no quests coplet ";
        }
        if (quest.CurrentQestsList.Count > 0)
        {
            for (int i = 0; i < quest.CurrentQestsList.Count; i++)
            {
                loss += quest.CurrentQestsList[i].QuestRespect / 2;
            }
        }
        for (int i = 0; i < quest.cargo.maxCargoLimit; i++)
        {

            if (i < quest.CompletQestList.Count)
            {
                if (quest.CompletQestList[i].Progress != QuestProgress.failed)
                {
                    Exp = quest.CompletQestList[i].ExpReward * quest.CompletQestList[i].cargo.GetComponent<CargoInformation>().CargoAmount;
                    quetSlots.text += quest.CompletQestList[i].QuestName + "  Exp:" + quest.CompletQestList[i].ExpReward + "\n";
                    #region cargo value coulataor 
                    if (quest.CompletQestList[i].vaule == CargoVaule.Common)
                    {
                        Questvaule = pricelist.CommonVaule;
                    }
                    if (quest.CompletQestList[i].vaule == CargoVaule.Uncommon)
                    {
                        Questvaule = pricelist.UncommonVale;
                    }
                    if (quest.CompletQestList[i].vaule == CargoVaule.Rare)
                    {
                        Questvaule = pricelist.UncommonVale;
                    }
                    Gold = Questvaule * quest.CompletQestList[i].cargo.GetComponent<CargoInformation>().CargoAmount;
                    gains += quest.CompletQestList[i].QuestRespect;
                  
                    #endregion 
                }
                if (quest.CompletQestList[i].Progress == QuestProgress.failed)
                {
                    loss += quest.CurrentQestsList[i].QuestRespect;
                }

                player.respectScore += gains-loss;
                player.gold += Gold;

            }
            gameover.SetActive(player.respectScore <= 0);
            newday.SetActive(player.respectScore > 0);
        }
    }
    public void endday()
    {
        Debug.Log("give the player gold and go the hq mode");
    }
    public void gameOver()
    {
        Debug.Log("game over");
    }
}
