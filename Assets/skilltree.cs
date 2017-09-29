using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skilltree : MonoBehaviour {
    public Text[] skills;
    public Text expText;
    //   public skilltreeButton [] Buttons;
    public GameObject[] Buttons;
    public PlaySatSheat stats;
    public int max;
     // Use this for initialization
    void Start () {
        stats = FindObjectOfType<PlaySatSheat>();
        expText.text = "current exp: " + stats.Exp;
        for (int i = 0; i <  skills.Length; i++)
        {
            skills[i].text = "";
            Buttons[i].SetActive(i < stats.TheStats.Count);
            if(i < stats.TheStats.Count)
            skills[i].text = stats.TheStats[i].StatName + " level " + stats.TheStats[i].StatLevel + "\n" + "Exp needed" + stats.TheStats[i].ExpNeeded;
            Buttons[i].gameObject.GetComponent<skilltreeButton>().ID = i;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void addStats(int ID)
    {
        Debug.Log("hit");
        int exp = stats.TheStats[ID].ExpNeeded;

        if (stats.TheStats[ID].StatLevel<max && stats.Exp >= stats.TheStats[ID].ExpNeeded)
        {
            stats.Exp -= stats.TheStats[ID].ExpNeeded;
            stats.TheStats[ID].Stat += stats.TheStats[ID].StatBoost;
            stats.TheStats[ID].StatLevel++;
            if(stats.TheStats[ID].expProgresson == StatsBace.kindofExp.add)
            {
                stats.TheStats[ID].ExpNeeded += exp;
            }
            if(stats.TheStats[ID].expProgresson == StatsBace.kindofExp.times)
            {
                stats.TheStats[ID].ExpNeeded = exp * stats.TheStats[ID].Expmultiply;
            }

        }
    }
 
}
