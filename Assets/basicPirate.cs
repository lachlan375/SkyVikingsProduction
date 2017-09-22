using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicPirate : MonoBehaviour {
    public GameObject Spell;
    public basicBaot theBoat;
    public bool fired;
    public float realodTime;
    public int caroToSteal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(theBoat.Alert == true)
        {
            if (theBoat.ReachedDesnation == true)
        {
           if(fired == false)
            {
                    theBoat.cannon.transform.transform.LookAt(theBoat.Player);
                    StartCoroutine(fireTheCanons());
                    fired = true;
                   
            }
        }
        }
        
	}
    IEnumerator fireTheCanons()
    {
 
        var theSpell = Instantiate(Spell, theBoat.cannon.transform.position, transform.rotation);
        theSpell.GetComponent<steallCargo>().CargotoSteal = caroToSteal;

        Debug.Log("shoot");
            yield return new WaitForSeconds(realodTime);
            fired = false;
        theBoat.restart();
    }

 
    }

