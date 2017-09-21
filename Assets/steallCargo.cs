using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steallCargo : MonoBehaviour {
    public int CargotoSteal;
    public float speed;
 
    void Update()
    {
        transform.position += Vector3.forward *speed;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Boat"))
        {

            other.gameObject.GetComponent<theShip>().removeCargo(CargotoSteal);
            Destroy(gameObject);
        }
    }
}
