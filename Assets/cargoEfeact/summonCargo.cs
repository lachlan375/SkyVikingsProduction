using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonCargo : MonoBehaviour {
    public GameObject Efeact;
    void OnEnable()
    {
        Instantiate(Efeact, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
    }
    void OnDestroy()
    {
      //  Instantiate(Efeact, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
    }



}
