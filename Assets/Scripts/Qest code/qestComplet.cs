using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qestComplet : MonoBehaviour {
    [HideInInspector]
    public playerStats stats;
    [HideInInspector]
    public BoatCargo done;
    public postmaster boss;
     public GameObject merchant;
    public GameObject QestComplet;
    public string townName;
    // Use this for initialization

    void Start()
    {
        stats = FindObjectOfType<playerStats>();
        done = FindObjectOfType<BoatCargo>();
        townName = name;
    }
    public void finshed()
    {
        Time.timeScale = 0;
        Debug.Log("done");
        done.finshed();
        QestComplet.GetComponent<qestCompletUI>().qestM = gameObject.GetComponent<qestComplet>();
        QestComplet.SetActive(true);
 

    }
    public void startQest()
    {
        merchant.GetComponent<merchantUI>().ThePostMaster = boss;
        merchant.SetActive(true);

    }

    void OnTriggerEnter(Collider other)
    {
 
         if (other.tag.Equals("Player"))
        {
            if(stats.Destination == townName)
            {
                finshed();               
                Debug.Log("yes");
            }
            if (stats.Destination != townName)
            {
                Debug.Log("no");
            }
        }


    }
}
