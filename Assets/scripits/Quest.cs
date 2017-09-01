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
    public string QueststLocation;
    [Tooltip("just put the gole in here")]
    public GameObject qestLocationGameObject;   
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
    public CargoVaule vaule;
    public List<CargoInformation> TheCargo = new List<CargoInformation>();
    public void setup()
    {
        QueststLocation = qestLocationGameObject.name;
    }



}
