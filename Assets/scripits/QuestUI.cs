﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestUI : MonoBehaviour {
    public string Dayover;
    [Header("list  of quest items")]
    public List<QuestObject> Quests = new List<QuestObject>();
    public QuestManager ThePlayer;
    [Header("quest setup")]
    [Tooltip("the panel")]
    public GameObject QuestsMenu;
    public GameObject QuestOver;
    [Tooltip("the npc quest givers name")]
    public Text header;
    [Tooltip("the flavor text")]
    public Text flavorText;
    public Text [] questText;
    public GameObject[] Buttons;
    public int ID;
    public theShip Ship;
    public GameObject newQuests;
    public GameObject dayover;

    [Tooltip("Pause and Unpause Menu fuctionality")]
    public PauseMenuActivation pauseMenu;
    // Use this for initialization
    void Start () {
        QuestsMenu.SetActive(false);
        QuestOver.SetActive(false);
	}
    void OnEnable()
    {
        header.text = Quests[0].QuestGIverName;
        flavorText.text = Quests[0].flavorText;
        QuestOver.SetActive(true);
        menuSetup(0);
        

    }
    public void queestOver()
    {
        dayover.SetActive(true);
        Debug.Log("its over");
    }


    public void turnon(string TownName)
    {
        for(int i = 0; i<Quests.Count; i++)
        {
            if (Quests[i].TownName == TownName)
            {
                header.text = Quests[i].QuestGIverName;
                flavorText.text = Quests[i].flavorText;
                QuestOver.SetActive(true);
                menuSetup(i);
            }
        }
        //Pause Menu is activated when Fucnction QuestUI is turned On
        pauseMenu.MenuOn();
    }
    public void  menuSetup(int townID)
    {
        bool questsAvalable = true;
        ID = townID;
       int textcount = 0;
        for(int i =0; i< questText.Length; i++)
        {
            questText[i].text = "";
            Buttons[i].SetActive(false);
            if (i< Quests[townID].AvailableQuests.Count)
            {
                if (Quests[townID].AvailableQuests[i].Progress == QuestProgress.Available)
                {
                    Buttons[textcount].SetActive(true);
                    questText[textcount].text = "Cargo:" + Quests[townID].AvailableQuests[i].QuestName + "\n" + "Vaule:" + Quests[townID].AvailableQuests[i].vaule+"\n"+ "Deliver to:" + Quests[townID].AvailableQuests[i].QueststLocation;
                    Buttons[textcount].gameObject.GetComponent<QuestButton>().QuestName = Quests[townID].AvailableQuests[i].QuestName;
                    textcount++;
                  
                }

            }
        }
        if(textcount == 0)
        {
            questsAvalable = false;
            questText[0].text = "NO QUESTS";

        }
        newQuests.SetActive(questsAvalable);
        QuestOver.SetActive(true);

    }
    public void Quit()
    {
        
        QuestOver.SetActive(false);
        QuestsMenu.SetActive(false);
        ThePlayer.TheQuestComplet = false;
        pauseMenu.MenuOff();
    }
    public void takeAnewQuest()
    {
        
        QuestOver.SetActive(false);
        QuestsMenu.SetActive(true);
        ThePlayer.TheQuestComplet = false;
        

    }
    public void endDay()
    {
        Debug.Log("dayover");
      ///  SceneManager.LoadScene(Dayover);
      //// something lachlan needs to sort out
    }
    public void startQuest(string QuestName)
    {
        Debug.Log("Start qu3est ACTIVATED!!!");
for(int i=0; i<Quests[ID].AvailableQuests.Count; i++)
        {
            if(QuestName == Quests[ID].AvailableQuests[i].QuestName)
            {
                ThePlayer.CurrentQestsList.Add(Quests[ID].AvailableQuests[i]);
                Quests[ID].AvailableQuests[i].Progress = QuestProgress.Accepted;
                Ship.loadTheboat(ID, i);
                QuestsMenu.SetActive(false);
            }
        }
        pauseMenu.MenuOff();
    }
}
