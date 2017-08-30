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
    [Tooltip("this is here to talk to the other islands dont touch it")]
    public string QueststLocation;
    [Tooltip("just put the gole in here")]
    public GameObject qestLocationGameObject;
    [Tooltip("The next quest")]
    public int NextQest;
    [Header("Quest goles")]
    [Tooltip("name of the qest objctive")]
    public string QuestObjective;
    [Tooltip("curent number of qest objctive")]
    public int QestObjectiveCout;
    [Tooltip("Qest Requirements")]
    public int QuestObjectiveRequirements;
    [Header("Quest rewards")]

    [Tooltip("how much Exp to hand out")]
    public int ExpReward;
    public BoatCargo vaule;
    public void setup()
    {
        QueststLocation = qestLocationGameObject.name;
    }



}
