using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellcCntroller : MonoBehaviour {
    public float Speed;
    public GameObject [] Efeacts;
    public ParticleSystem expload;
    public bool hit;
    public float timer;
    public float maxTime;
    public bool pirate;
    public int CargotoSteal;
    void OnEnable()
    {
        hit = false;
        timer = 0;
        Efeacts[0].SetActive(true);
        Efeacts[1].SetActive(false);
    }
    void Update () {
        timer += 0.1f;


        if (hit == false)
        {
        transform.Translate(Vector3.forward*Speed);
        }
        if(hit == true)
        {

             Efeacts[0].SetActive(false);
            Efeacts[1].SetActive(true);
            if(!expload.IsAlive())
            {
                Destroy(gameObject);
            }

        }
      
        if(timer >= maxTime)
        {
            if(hit == false)
            {
            Efeacts[1].SetActive(true);
            hit = true;
           }           
          
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if(pirate == true)
        {
            if (other.tag.Equals("Boat"))
            {
                 if(hit == false)
                {
                    if (other.gameObject.GetComponent<theShip>())
                other.gameObject.GetComponent<theShip>().removeCargo(CargotoSteal);
                    hit = true;
                }
            }

        }
        

    }
    public void finshed()
    {
        Destroy(gameObject);
    }

}

 
