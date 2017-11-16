using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStartStop : MonoBehaviour {
    public Animator Ani;
    // Use this for initialization
    void OnEnable()
    {
        Ani = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    void play()
    {
        GetComponent<Animator>().enabled = !true;
    }

    IEnumerator Restart()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
        }
    }
}
