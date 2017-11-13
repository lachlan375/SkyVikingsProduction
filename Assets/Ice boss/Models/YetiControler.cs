using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YetiControler : MonoBehaviour
{
    public AudioSource soundEfeact;
    public AudioClip rawSoundEfeact;
    public Animator YetiAini;
    public gunContoler throwSnowbal;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void throwball()
    {
        YetiAini.SetBool("throwing", true);
    }
 
    public void finshed()
    {
        throwSnowbal.startfire();
        YetiAini.SetBool("throwing", false);
    }
    public void raw()
    {
        soundEfeact.PlayOneShot(rawSoundEfeact, 1.0F);
        Debug.Log("playsound");
    }
}
