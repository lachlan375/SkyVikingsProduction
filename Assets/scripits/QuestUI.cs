using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour {
    [Header("list  of quest items")]
    public List<QuestObject> Quests = new List<QuestObject>();
    public QuestManager ThePlayer;
    [Header("quest setup")]
    [Tooltip("the panel")]
    public GameObject QuestsMenu;
    [Tooltip("the npc quest givers name")]
    public Text header;
    [Tooltip("the flavor text")]
    public Text flavorText;
    public Text [] questText;
    public GameObject[] Buttons;
    public int ID;
    public theShip Ship;
    // Use this for initialization
    void Start () {
        QuestsMenu.SetActive(false);	
	}
    void OnEnable()
    {
        menuSetup(0);
        header.text = Quests[0].QuestGIverName;
        flavorText.text = Quests[0].flavorText;
    }


    // Update is called once per frame

    public void turnon(string TownName)
    {
        for(int i = 0; i<Quests.Count; i++)
        {
            if (Quests[i].TownName == TownName)
            {
                header.text = Quests[i].QuestGIverName;
                flavorText.text = Quests[i].flavorText;
                QuestsMenu.SetActive(true);
                menuSetup(i);
            }
        }
     }
    public void  menuSetup(int townID)
    {
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
            questText[0].text = "NO QUESTS";

        }
        QuestsMenu.SetActive(true);

    }
    public void startQuest(string QuestName)
    {
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

    }
}
