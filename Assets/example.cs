using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class example : MonoBehaviour {
    public PlaySatSheat stats;
    public string stat;
    public float speed;
    // Use this for initialization
    void Start () {

        stats = FindObjectOfType<PlaySatSheat>();
        foreach (StatsBace item in stats.TheStats)
        {

if(item.StatName == stat)
            {
                speed = item.Stat;
            }
                    }

    }
	
	// Update is called once per frame
	void Update () {
	}

}
