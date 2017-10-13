using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    public GameObject spike, shatteredSpike;

    [Range(0, 50)]
    public float spikeHeight;
    float wait, rand;

    [Range(1, 600)]
    public float explosionRadius;
    public float force;

    Vector3 spawnPos;
    public AudioClip crackAudioClip;

    bool destroyed = false;

    void Start()
    {
        spawnPos = gameObject.transform.position;
        rand = Random.Range(3.0f, 10.0f);
    }

    void Update()
    {
        wait += Time.deltaTime;
        if (wait >= rand && destroyed)
        {
            destroyed = false;
            // var go = Instantiate(spike, new Vector3(spawnPos.x, spikeHeight, spawnPos.z), transform.rotation);
            // go.name = spike.name;
            // Destroy(gameObject);
            gameObject.transform.position = spawnPos;
            this.GetComponent<MeshRenderer>().enabled = true;
            this.GetComponent<BoxCollider>().enabled = true;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            wait = 0;
        }
    }

    /* OBJECT POOLING
     * The idea is you have a list of objects which get re used
     * When destroying one, simply disable the object.
     * Next time you need a new one, call a function which searches the list for the first disabled one.
     * Then you can re enable it, and reuse it.
     * If no disabled ones are found, create a new one and add to the list. */

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Base")
        {
            AudioSource.PlayClipAtPoint(crackAudioClip, col.transform.position, 1f);
            transform.parent = null;
            var s2 = Instantiate(shatteredSpike, transform.position, transform.rotation);
            s2.GetComponent<DestroyShatteredSpike>().DestroyShatter();
            Shockwave();
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void Shockwave()
    {
        destroyed = true;
        var col = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider coll in col)
        {
            Rigidbody rb = coll.GetComponent<Rigidbody>();
            if (rb)
            {
                float proximity = (transform.position - coll.transform.position).magnitude;
                float effect = force - (proximity / explosionRadius);
                rb.AddExplosionForce(effect, transform.position, explosionRadius);
            }
        }
    }
}