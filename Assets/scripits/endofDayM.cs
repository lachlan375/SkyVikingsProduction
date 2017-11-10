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
    private int loss;
    public int gains;
    public Text respectText;
    public ObjectPriceList maxCargo;
    // Use this for initialization

    void Start()
    {
        quest = GameObject.FindGameObjectWithTag("GameController").GetComponent<QuestManager>();

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
        for (int i = 0; i < quest.maxCargo; i++)
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
                        Questvaule = maxCargo.CommonVaule;
                    }
                    if (quest.CompletQestList[i].vaule == CargoVaule.Uncommon)
                    {
                        Questvaule = maxCargo.UncommonVale;
                    }
                    if (quest.CompletQestList[i].vaule == CargoVaule.Rare)
                    {
                        Questvaule = maxCargo.UncommonVale;
                    }
                    Gold = Questvaule * quest.CompletQestList[i].cargo.GetComponent<CargoInformation>().CargoAmount;
                    Exp += quest.CompletQestList[i].ExpReward;
                    gains += quest.CompletQestList[i].QuestRespect;
                    #endregion 
                }
                if (quest.CompletQestList[i].Progress == QuestProgress.failed)
                {
                    loss += quest.CurrentQestsList[i].QuestRespect;
                }

            }


        }
    }
}
