using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qestComplet : MonoBehaviour {
    public merchantUI merchantui;
    public postmaster boss;
    public GameObject merchant;
    public GameObject QestComplet;
    public string townName;
     // Use this for initialization
 
          public void finshed()
    {
        Time.timeScale = 0;
        Debug.Log("done");
        QestComplet.GetComponent<qestCompletUI>().qestM = gameObject.GetComponent<qestComplet>();
        QestComplet.SetActive(true);
 
    }
    void OnTriggerEnter(Collider other)
    {
if(other.gameObject.GetComponent<playerStats>().Destnation == townName)
        {
            Debug.Log("you win");
        }
            }
    public void startQest()
    {
        merchant.GetComponent<merchantUI>().ThePostMaster = boss;
        merchant.SetActive(true);

    }

}
