using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skilltree : MonoBehaviour {
    public Text[] skills;
    public Text expText;
 ///   public skilltreeButton [] Buttons;
    public GameObject[] Buttons;
    public PlaySatSheat stats;
    public int max;
    // Use this for initialization
    void OnEnable()
    {
        Debug.Log(gameObject);
        int cout = 0;
        stats = FindObjectOfType<PlaySatSheat>();
        expText.text = "current exp: " + stats.Exp;
        for (int i = 0; i <  skills.Length; i++)
        {
            skills[i].text = "";
            Buttons[i].SetActive(i < stats.TheStats.Count);
            if (i < stats.TheStats.Count)
            {
 
                skills[cout].text = stats.TheStats[cout].StatName + " level " + stats.TheStats[cout].StatLevel + "\n" + "curent Exp" + stats.TheStats[cout].CurentExp +"\n"+ "Exp needed" + stats.TheStats[cout].ExpNeeded;
            Buttons[cout].gameObject.GetComponent<skilltreeButton>().ID = i;
                cout ++;
            }
   
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
 
    public void addStats(int ID)
    {
        Debug.Log("Add exp");
       
        if(stats.Exp >0 && stats.TheStats[ID].StatLevel != stats.TheStats[ID].maxLevel)
        {
            stats.TheStats[ID].CurentExp += 1;
            stats.Exp -= 1;
            if (stats.TheStats[ID].ExpNeeded == stats.TheStats[ID].CurentExp)
            {
                stats.TheStats[ID].StatLevel++;
                Debug.Log("exp"+ stats.TheStats[ID].Expmultiply);
                stats.TheStats[ID].CurentExp = 0;
                stats.TheStats[ID].ExpNeeded = stats.TheStats[ID].StatLevel * stats.TheStats[ID].Expmultiply;
if(stats.TheStats[ID].StatKind == StatsBace.kindOfstat.FLoat)
                {
                    stats.TheStats[ID].StatFLoat++;
                }
            }
            if (stats.TheStats[ID].StatKind == StatsBace.kindOfstat.Int)
            {
                stats.TheStats[ID].statInt++;
            }
        }
        skills[ID].text = stats.TheStats[ID].StatName + " level " + stats.TheStats[ID].StatLevel + "\n" + "curent Exp" + stats.TheStats[ID].CurentExp + "\n" + "Exp needed" + stats.TheStats[ID].ExpNeeded;
        expText.text = "current exp: " + stats.Exp;
 


    }

}
