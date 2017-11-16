using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargoremoved : MonoBehaviour {
    public Animation thecargo;

    public void play()
    {
        thecargo.Play();

    }
    public void stop()
    {
        thecargo.Stop();
    }
}
