using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class StatsBace
{
    public enum kindOfstat { FLoat,Int}
    public enum kindofExp { add,times}
    [Tooltip("the name of the Stat")]
    public string StatName;
    [Tooltip("the Level of the stat")]
    public int StatLevel;
    [Tooltip("the stat")]
    public float StatFLoat;
    public int statInt;
    public kindOfstat StatKind;
    [Tooltip("how much to edvance the stat")]
    public float StatBoost;
    [Tooltip("How much exp you will need to get to the next stage")]
    public int ExpNeeded;
    public int CurentExp;
    [Tooltip("this coulates exp")]
    public int Expmultiply;
    public kindofExp expProgresson;
    public int maxLevel;
}
