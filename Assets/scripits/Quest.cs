using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Quest

{
    [Header("Quest information")]
    [Tooltip("Qest name")]
    public string QuestName; 
    [Tooltip("Track qests progress")]
    public QuestProgress Progress;

    [Tooltip("Qests description")]
    public string QuestDescription;
    [Tooltip("Give players A quck hinit")]
    public string Hint;
[HideInInspector]
     [Tooltip("just put the gole in here")]
    public GameObject qestLocationGameObject;   
    [Header("Quest goles")]
    [Tooltip("name of the qest objctive")]
    public string QuestObjective;
    [Tooltip("curent number of qest objctive")]
    [Header("Quest rewards")]

    public int ExpReward;
    [Tooltip("how much Exp to hand out")]
    public CargoVaule vaule;
    public ObjectPriceList price;
    public int RespectLevelNeeded;
    [Tooltip("if the quest is complet  you earn this if you louse you louse this")]
    public int QuestRespect;
    public int goldFOrquest;
    [Tooltip("this is to help check if  the cargo made it ")]
    public string MercantscargoName;
    public GameObject cargo;
    public bool loaded;
     public void setup()
    {

        cargo.GetComponent<CargoInformation>().CargoDesnation = qestLocationGameObject.name;
     }
    public void ExpTogive(int caroAmount)
    {
        int expGive = 0;
        if(vaule == CargoVaule.Common)
        {
            expGive = price.CommonVaule;
        }
        if (vaule == CargoVaule.Uncommon)
        {
            expGive = price.UncommonVale;
        }
        if (vaule == CargoVaule.Rare)
        {
            expGive = price.RareVaule;
        }
        for (int i = 0; i<caroAmount; i++)
        {
            ExpReward += expGive;
        }
    }


}
