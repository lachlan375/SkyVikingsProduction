using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;
using UnityEngine.UI;

public class Geyser : MonoBehaviour
{
    private IEnumerator coroutine1;

    public float thrust = 100;

    public AudioSource woosh;

    private ParticleSystem particle;

    void Start()
    {
        particle = gameObject.GetComponent<ParticleSystem>();
        coroutine1 = Push();

        if (enabled)
        {
            StartCoroutine(coroutine1);
        }
    }

    IEnumerator Push()
    {
        while (enabled)
        {
            //particle.Play();
            //woosh.Play();
            ApplyForce();
            yield return new WaitForSeconds(1);
        }
    }

    void ApplyForce()
    {
        BoxCollider box = gameObject.GetComponent<BoxCollider>();
        Collider[] cols = Physics.OverlapBox(transform.TransformPoint(box.center), transform.TransformVector(box.size), transform.rotation, (1 << /* ONLY Layer: */ 8));
        foreach (Collider col in cols)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();
            if (rb)
                rb.AddForce(transform.forward * thrust);
        }
    }
}
