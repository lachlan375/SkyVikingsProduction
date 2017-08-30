using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DayOver : MonoBehaviour {
    public Text [] thetext;
     public int couter;
    public GameObject []  nextAndBack;   
    public string nubers;
    public QuestManager QuestComplet;
    public ObjectPriceList price;
     private int box;
     public GameObject ui;
    public sunAndmoon sunDown;
    public bool dayover;
    // Use this for initialization
    void OnEnable()
    {
       // sunDown.andStop();
        couter = 0;
         cargo();
        dayOver();
        dayover = true;
    }
        // Update is called once per frame
        void Update () {
		
	}
    public void cargo()
    {
        int TheScore = 0;
   for(int i =0; i < thetext.Length; ++i)
        {
            thetext[i].text = "";
            if(i<QuestComplet.CompletQestList.Count)
            {
                thetext[i].text = QuestComplet.CompletQestList[i].QuestName;
                TheScore += 1;
            }
        }
            nubers = "gold :" + TheScore;
     }
    public void dayOver()
    {
  
 
    }
    public void ANewday()
    {

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
