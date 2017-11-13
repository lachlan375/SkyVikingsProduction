using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButton : MonoBehaviour {
    public Button TheButton;
    public string QuestName;
    public QuestUI TheQuest;
	// Use this for initialization
	void Start () {
        TheButton.onClick.AddListener(OnButtonClick);
    }
    void OnButtonClick()
    {
        Debug.Log("Quest button pressed");
        TheQuest.choseQuest(QuestName);
    }

}
