using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCanvas : MonoBehaviour {

    public GameObject victoryScreen;

    void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Player")
        {
            victoryScreen.SetActive(true);
        }
    }
}
