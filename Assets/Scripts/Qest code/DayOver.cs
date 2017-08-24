using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DayOver : MonoBehaviour {
    public playerStats stats;
    public Text [] thetext;
     public int couter;
    public GameObject []  nextAndBack;
   
    public string nubers;
    public ObjectPriceList price;
    public int score;
    private int box;
    public postmaster thepostmaster;
    public GameObject ui;
    public sunAndmoon sunDown;
    public bool dayover;
    // Use this for initialization
    void OnEnable()
    {
        sunDown.andStop();
        couter = 0;
        stats = FindObjectOfType<playerStats>();
        cargo();
        dayOver();
        dayover = true;
    }
        // Update is called once per frame
        void Update () {
		
	}
    public void cargo()
    {
        for(int M = 0; M<stats.finshedQuests.Count;  M++)
        {
            box = stats.finshedQuests[M].cratesDeliverd;
            if(box == 0)
            {
                box = 1;
            }
            if (stats.finshedQuests[M].value == crateValue.Common)
            {
                score += price.CommonVaule*box;
            }
            if (stats.finshedQuests[M].value == crateValue.Uncommon)
            {
                score += price.UncommonVale * box;
            }
            if (stats.finshedQuests[M].value == crateValue.Rare)
            {
                score += price.RareVaule * box;
            }

        }
        nubers = "gold :" + score;
     }
    public void dayOver()
    {
        Debug.Log("im hit");
      
        if(couter < stats.finshedQuests.Count)
        {
                        for (int I = 0; I < thetext.Length; I++)
            {
                 thetext[I].text = "";
                if (couter < stats.finshedQuests.Count)
                {
                thetext[I].text =   stats.finshedQuests[couter].CargoName +"\n"+ "  value : " + stats.finshedQuests[couter].value;
             }
            if (couter == stats.finshedQuests.Count)
                {
                    thetext[I].text = nubers;
                }
                 couter++;
        }
        
        }
 
 
    }
    public void ANewday()
    {
        while(stats.finshedQuests.Count != 0)
        {
            stats.finshedQuests.Remove(stats.finshedQuests[0]);
        }
        ui.gameObject.GetComponent<merchantUI>().ThePostMaster = thepostmaster;
        ui.SetActive(true);
        gameObject.SetActive(false);
        sunDown.andStop();

    }
    public void back()
    {
        couter -= thetext.Length;
        if(couter <0)
        {
            couter = 0;
        }
        nextAndBack[1].SetActive(false);
        Debug.Log(couter);
        dayOver();

    }
}
