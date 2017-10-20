using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qustsInfo : MonoBehaviour {
    public Text QuestText;
    public QuestManager theQuests;
    public GameObject QuestLog;
    public bool use;
    public bool cantUse;
    private bool reading;
    // Use this for initialization
    void Start()
    {
        theQuests = FindObjectOfType<QuestManager>();
        QuestLog.SetActive(false);

    }

    public void questUpdated () {
        QuestText.text = "";
        QuestLog.SetActive(true);
        foreach (Quest Quests in theQuests.CurrentQestsList)
        {
            QuestText.text += "name" + Quests.QuestName + "\n" + " location " + Quests.QueststLocation +"\n"+ "hint"+ Quests.Hint + "\n" ;
        }
 	}
	
	// Update is called once per frame
	void Update () {
        if(cantUse == false )
            if (Input.GetButtonDown("Quest"))
            {
                if (reading == false)
                {
                Debug.Log("hit");
                 if(use == false)
                {
                        reading = true;
                        StartCoroutine(readingit());
                    questUpdated();
                 }
                 if(use == true)
                {
                    QuestLog.SetActive(false);
                        reading = true;
                        StartCoroutine(readingit());
                    }
                }

            }
 
    }
    IEnumerator readingit()
    {
        yield return new WaitForSeconds(0.5f);
        use =!use;
        reading = false;
    }

}
