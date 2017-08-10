using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretary : MonoBehaviour {
    public merchantUI merchant;
    public postmaster boss;
    public GameObject list;
    
    


    // Update is called once per frame
    void OnEnable() {
         merchant.ThePostMaster = boss;
        list.SetActive(true);
        }
 
       	
	}
  
