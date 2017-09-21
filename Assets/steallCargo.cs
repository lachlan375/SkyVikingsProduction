using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steallCargo : MonoBehaviour {
    public int CargotoSteal;
    public float speed;
  public float spellTimeDuration;
    public Rigidbody bullet;

    void Start()
    {


    }
    void Update()

    {
        bullet.velocity = gameObject.transform.forward;

        spellTimeDuration -= Time.deltaTime;

        if (spellTimeDuration <= 0)
        {
            Destroy(gameObject);
        }
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
