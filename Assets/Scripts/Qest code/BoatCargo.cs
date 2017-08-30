using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCargo : MonoBehaviour {


    public playerStats player;
    [Tooltip("to make things eazer for blanceing the vaule of cargo is fixed tp this scripit ")]
    public ObjectPriceList priceForCargo;
    [HideInInspector]
    public List<CrateInformation> information = new List<CrateInformation>();
    [HideInInspector]
    public List<summonBox> boxes = new List<summonBox>();
    [Tooltip("the slots where your ships cargo will go")]
    public Transform [] ShipCargoHold;
    [Tooltip("its the deck of the boat were the objects will sit")]
    public Transform ShipsDeck;
    [Tooltip("this is so the ships cargo will move with the ship")]
    public GameObject CargoHold;
    [Tooltip("when the quests done it will remove the boxes")]
    public bool Complet;
    public bool fanncyShiping;
    public float time; 
    
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<playerStats>();
	}
	
	// Update is called once per frame
	void Update () {

       
	}
    public void finshed()
    {
         player.curentQest[0].cratesDeliverd = boxes.Count;
         Debug.Log(player.curentQest[0].cratesDeliverd);
 player.finshedQuests.Add(player.curentQest[0]);
   player.curentQest.Remove(player.curentQest[0]);

        if (fanncyShiping == true)
        {
            StartCoroutine(Flashy());
        }
        if (fanncyShiping == false)
        {
            for(int i = 0; information.Count>0; i++)
            {


                boxes[0].finshedQest();
                information.Remove(information[0]);
                boxes.Remove(boxes[0]);

            }
        }

    }
    IEnumerator Flashy()
    {
        while(information.Count > 0)
        {
             boxes[0].finshedQest();
            boxes.Remove(boxes[0]);
            information.Remove(information[0]);
            Debug.Log("hay");
            yield return new WaitForSeconds(time);
        }

    }
    public void fail()
    {
        for (int i = 0; information.Count > 0; i++)
        {


            boxes[0].desorySelf();
            information.Remove(information[0]);
            boxes.Remove(boxes[0]);

        }
    }
   
}
