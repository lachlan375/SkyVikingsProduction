using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qestComplet : MonoBehaviour {
    public postmaster boss;
    public GameObject merchant;
    public GameObject QestComplet;
     // Use this for initialization
 
          public void finshed()
    {
        Time.timeScale = 0;
        Debug.Log("done");
        QestComplet.GetComponent<qestCompletUI>().qestM = gameObject.GetComponent<qestComplet>();
        QestComplet.SetActive(true);
 
    }
    public void startQest()
    {
        merchant.GetComponent<merchantUI>().ThePostMaster = boss;
        merchant.SetActive(true);

    }

}
