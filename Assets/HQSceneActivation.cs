using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HQSceneActivation : MonoBehaviour {

    
    public Transform hqTransform;
    public bool is_ActiveHQMode;        //flag to check if HQ Mode is active

    public GameObject playerContRef;
    //public CurrentShip instantBoat;
    public GameObject currentBoat;


    public Scene hq_Scene;
    public string hqString;


    // Use this for initialization
    void Start()
    {
        playerContRef = GameObject.FindGameObjectWithTag("GameController");
        currentBoat = playerContRef.GetComponent<CurrentShip>().instantiatedShip;


        hqTransform = GameObject.FindGameObjectWithTag("Respawn").transform;
        
        currentBoat = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (is_ActiveHQMode)
        {
            HQActivation();
        }

        else
        {

        }
    }

    void HQActivation()
    {
        currentBoat.transform.position = hqTransform.transform.position;
        //freeze animation + lock boat
        //particle effect
    }

    public void HQNewBoat()
    {

    }
}
