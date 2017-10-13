using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;
using UnityEngine.UI;

public class Geyser : MonoBehaviour
{
    public float force, explosionRadius;
    float wait, rand;

    public AudioClip whoosh;

    ParticleSystem particle;

    void Start()
    {
        particle = gameObject.GetComponent<ParticleSystem>();
        rand = Random.Range(3.0f, 7.0f);
    }

    void Update()
    {
        wait += Time.deltaTime;

        if (wait >= rand)
        {
            DOTHINGFUCK();
            wait = 0;
            rand = Random.Range(3.0f, 7.0f);
        }
    }

    void DOTHINGFUCK()
    {
        particle.Play();
        ApplyForce();
        AudioSource.PlayClipAtPoint(whoosh, transform.position, 1f);
    }

    void ApplyForce()
    {
        BoxCollider box = gameObject.GetComponent<BoxCollider>();
        Collider[] col = Physics.OverlapBox(transform.position, Vector3.Scale(box.size, transform.lossyScale * 0.5f), transform.rotation);
        foreach (Collider coll in col)
        {
            Rigidbody rb = coll.GetComponent<Rigidbody>();
            if (rb)
            {
                //rb.AddForce(transform.forward * thrust);
                //Vector3 direction = col
                float proximity = (transform.position - coll.transform.position).magnitude;
                float effect = force - (proximity / explosionRadius);
                rb.AddForce(transform.up * effect, ForceMode.Force);
            }
        }
    }
}
