﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicPirate : MonoBehaviour
{
    public basicBaot theBoat;
    [HideInInspector]
    public bool fired;
  
    public float realodTime;
    [Tooltip("this can be enything its just a place holder name ")]
    public gunContoler gun;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (theBoat.Alert == true)
        {
            if (theBoat.ReachedDesnation == true)
            {
                if (fired == false)
                {
                    StartCoroutine(fireTheCanons());
                    fired = true;
                    Debug.Log("boom");
                }
            }
        }

    }
    IEnumerator fireTheCanons()
    {
        gun.startfire();
        yield return new WaitForSeconds(realodTime);
        fired = false;
        theBoat.restart();
    }


}

