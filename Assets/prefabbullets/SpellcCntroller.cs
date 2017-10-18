using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellcCntroller : MonoBehaviour {
    public float Speed;
    public GameObject [] Efeacts;
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

        if (hit == false)
        {
        timer += 0.1f;
        transform.Translate(Vector3.forward*Speed);
        }
        if(hit == true)
        {
             Efeacts[0].SetActive(false);
            Efeacts[1].SetActive(true);
        }
      
        if(timer >= maxTime)
        {
            Efeacts[1].SetActive(true);
            hit = true;
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if(pirate == true)
        {
            if (other.tag.Equals("Boat"))
            {
                hit = true;
                Debug.Log("push a thing ");
                other.gameObject.GetComponent<theShip>().removeCargo(CargotoSteal);
                Destroy(gameObject);
            }

        }


    }
    public void finshed()
    {
        Destroy(gameObject);
    }

}

 
