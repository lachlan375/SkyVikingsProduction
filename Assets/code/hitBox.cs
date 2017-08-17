using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBox : MonoBehaviour
{

    [Header("in the the box")]
    public bool inTheBox;
    public bool npcInbox;
    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Player"))
        {
            inTheBox = true;
        }

        if (other.tag.Equals("NPC"))
        {
            npcInbox = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            inTheBox = false;
        }
        if (other.tag.Equals("NPC"))
        {
            npcInbox = false;
        }

    }
    void OnDisable()
    {
        inTheBox = false;
        npcInbox = false;
    }




}
