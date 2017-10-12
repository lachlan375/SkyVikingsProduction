using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;
using UnityEngine.UI;

public class Geyser : MonoBehaviour
{
    public float force = 100;

    public AudioClip whoosh;

    private ParticleSystem particle;
    BoxCollider falloff;

    void Start()
    {
        falloff = gameObject.GetComponent<BoxCollider>();
        particle = gameObject.GetComponent<ParticleSystem>();
        StartCoroutine(Push());
    }

    IEnumerator Push()
    {
        while (enabled)
        {
            particle.Play();
            ApplyForce();
            AudioSource.PlayClipAtPoint(whoosh, transform.position, 1f);
            yield return new WaitForSeconds(5);
        }
    }

    void ApplyForce()
    {
        BoxCollider box = gameObject.GetComponent<BoxCollider>();
        Collider[] col = Physics.OverlapBox(transform.position, falloff.size); //transform.TransformPoint(box.center), transform.TransformVector(box.size), transform.rotation, (1 << /* ONLY Layer: */ 8));
        foreach (Collider coll in col)
        {
            Rigidbody rb = coll.GetComponent<Rigidbody>();
            if (rb)
            {
                //rb.AddForce(transform.forward * thrust);
                float proximity = (transform.position - coll.transform.position).magnitude;
                float effect = force - (proximity / falloff.size.y);
                rb.AddExplosionForce(effect, transform.position, falloff.size.y);
            }
        }
    }
}
