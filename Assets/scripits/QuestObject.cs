using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {


    [Header("Quests giver information")]
    [Tooltip("this dosent need to be filled out the game object becomes the  names")]
    public string TownName;
    [Tooltip("someting about there store")]
    public string townHinit;
    [Tooltip("this is the qest givers name it can be ennything you like")]
     public string QuestGIverName;
    [Tooltip("someting about there store")]
    public string flavorText;
    public QuestUI questUI;
    [Header("Quests to give")]
    [Tooltip("Qest ID")]
    public ObjectPriceList Caroprice;
    public List<Quest> AvailableQuests = new List<Quest>();
    public Camera mercantsFaceCam;
      public bool inTheBox;
    public GameObject mercantsFaceCamobject;
      void Start ()
    {
        mercantsFaceCamobject.SetActive(false);
        mercantsFaceCam = mercantsFaceCamobject.GetComponent<Camera>();
        Caroprice = FindObjectOfType<ObjectPriceList>();
        TownName = gameObject.name;
        for(int i = 0; i<AvailableQuests.Count; i++)
        {
            Debug.Log("YO"+gameObject);
            if(AvailableQuests[i].qestLocationGameObject.GetComponent<QuestObject>() != null)
            {
            AvailableQuests[i].Hint = AvailableQuests[i].qestLocationGameObject.GetComponent<QuestObject>().townHinit;
            }
            else
            {
                AvailableQuests[i].Hint = "cant find quest";
            }
        }
 for(int i = 0; i < AvailableQuests.Count; i++)
        {
            AvailableQuests[i].setup();
            AvailableQuests[i].price = Caroprice;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(inTheBox == true)
        {
            if (Input.GetKeyDown(KeyCode.Space)) 

            {
                mercantsFaceCamobject.SetActive(true);
                questUI.turnon(TownName);
                inTheBox = false;

            }
        }
     

    }
    #region trigers
    void OnTriggerEnter(Collider other)
    {
 
         if (other.tag == "Player")
        {
            other.gameObject.GetComponentInParent<QuestManager>().completQests(TownName);
			if (other.gameObject.GetComponentInParent<QuestManager>().TheQuestComplet == false)
            {
                inTheBox = true;
                Debug.Log("hay");
            }
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
