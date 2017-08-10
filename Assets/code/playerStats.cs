using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour {
    public float curenthealth;
    public float Defence;
    public float strenth;
    public float totealweight;
    public float fuel;
    public float Vaule;
    public ShipStats ship;
    public List<items> invantory = new List<items>();
    public List<QestLog> curentQest = new List<QestLog>();
    public List<QestLog> finshedQuests = new List<QestLog>();
    private int couter;
     // Use this for initialization
    void Start () {
        checkWait();
    }

    // Update is called once per frame
    void Update() {

    }
    public void checkWait()
    {
        Vaule = 0;
        
        couter = 0;
        while (couter < invantory.Count)
        {
            Vaule += invantory[couter].ItemVaule;
            totealweight += invantory[couter].weight;
            couter += 1;
        }
    }
}
