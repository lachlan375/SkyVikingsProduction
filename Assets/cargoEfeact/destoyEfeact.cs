using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoyEfeact : MonoBehaviour {
    public ParticleSystem Effect;

    // Update is called once per frame
    void Update ()
    {
        if (Effect.isPlaying == false)
        {
            Destroy(gameObject);
        }


    }
}
