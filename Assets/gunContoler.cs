﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunContoler : MonoBehaviour {
    [Tooltip("the Spell")]
    public GameObject bullet;
    public Transform fireponit;
    public bool pirateShip;
    [Header("gun setings")]
    [Tooltip("is the gun on")]
    public bool Isfireing;
    public float bulletSpeed;
    public float TimeBetweenShots;
    private float shotcouter;
    public float maxshots;
    private int cargoToSteal;
     void Start () {
     }
	
	// Update is called once per frame
	void Update () {
		if(Isfireing == true)
        {
             var theSpell = Instantiate(bullet, fireponit.transform.position, fireponit.transform.rotation);
       }
	}
    public void startfire(int steal)
    {
        cargoToSteal = steal;
        var theSpell = Instantiate(bullet, fireponit.transform.position, fireponit.transform.rotation);
        theSpell.GetComponent<SpellcCntroller>().CargotoSteal = cargoToSteal;
    }
    public void throwSnowball()
    {
        Instantiate(bullet, fireponit.transform.position, fireponit.transform.rotation);
    }
}
