using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShatteredSpike : MonoBehaviour
{
    public float low, high;
    public bool parent;

    public ParticleSystem particle;

    public void DestroyShatter()
    {
        particle = gameObject.GetComponent<ParticleSystem>();
        Shader s = gameObject.GetComponent<Shader>();
        particle.Play();

        if (parent)
            Destroy(gameObject, high);
        else
            Destroy(gameObject, Random.Range(low, high));
    }
}
