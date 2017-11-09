using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerStats : MonoBehaviour {
    public static playerStats PlayerStats;
     [Header("Player Progress")]
    public int gold;
    public int respectScore;
    public Text respectText;

     // Use this for initialization
    void Awake()
    {
        if (PlayerStats == null)
        {
            PlayerStats = this;
        }
        else if (PlayerStats != this)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        respectText.text = "respect:" + respectScore;

    }




}
