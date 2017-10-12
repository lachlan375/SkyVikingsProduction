using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    public GameObject spike, shatteredSpike;

    [Range(0, 50)]
    public float spikeHeight;

    [Range(1, 600)]
    public float explosionRadius;
    public float force;

    Vector3 spawnPos;
    public AudioClip crackAudioClip;

    void Start()
    {
        spawnPos = gameObject.transform.position;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Base")
        {
            AudioSource.PlayClipAtPoint(crackAudioClip, col.transform.position, 1f);
            //crack = col
            //crack = GameObject.FindGameObjectWithTag("StalactiteSound").GetComponent<AudioSource>();

            transform.parent = null;
            var s2 = Instantiate(shatteredSpike, transform.position, transform.rotation);
            s2.GetComponent<DestroyShatteredSpike>().DestroyShatter();
            Instantiate();
            Destroy(gameObject);
        }
    }

    void Instantiate()
    {
        var go = Instantiate(spike, new Vector3(spawnPos.x, spikeHeight, spawnPos.z), transform.rotation);
        go.name = spike.name;
        var col = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider coll in col)
        {
            //if (coll.name.Contains("Ship"))
            //    Debug.Log(coll.name);
            Rigidbody rb = coll.GetComponent<Rigidbody>();
            if (rb)
            {
                //if (rb.mass > 500)
                //    force0 *= 10;
                float proximity = (transform.position - coll.transform.position).magnitude;
                float effect = force - (proximity / explosionRadius);
                rb.AddExplosionForce(effect, transform.position, explosionRadius);
            }
        }
    }
}