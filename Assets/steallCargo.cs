using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steallCargo : MonoBehaviour {
    public int CargotoSteal;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Boat"))
        {
            other.gameObject.GetComponent<theShip>().removeCargo(CargotoSteal);
        }       
    }
}
