using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {


    [Header("Quests giver information")]
    [Tooltip("this dosent need to be filled out the game object becomes the  names")]
    public string TownName;
    [Tooltip("this is the qest givers name it can be ennything you like")]
     public string QuestGIverName;
    [Tooltip("someting about there store")]
    public string flavorText;

    [Header("Quests to give")]
    [Tooltip("Qest ID")]
    public List<Quest> AvailableQuests = new List<Quest>();
      private bool inTheBox;
      void Start ()
    {
        TownName = gameObject.name;
 for(int i = 0; i < AvailableQuests.Count; i++)
        {
            AvailableQuests[i].setup();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
   
    }
    #region trigers
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
         if (other.tag == "Player")
        {
            inTheBox = true; 
            other.gameObject.GetComponent<QuestManager>().completQests(TownName);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inTheBox = false;
        }
    }
    #endregion

}
