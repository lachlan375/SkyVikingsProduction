using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum crateValue { Common, Uncommon,Rare }
public class postmaster : MonoBehaviour
{
    public Font postMasterHeader;
    public Font postMasterText;
    public Sprite PostmaterBackground;
    [Tooltip("the merchants name ")]
    public string PostMastrsName;
    [Tooltip("some flavor text ")]
    public string Desciption;
    [Tooltip("the qest list")]
    public postMan[] Orders;
    [Tooltip("the quest you what")]
    public int Number;
    [Tooltip("load the boat")]
    public bool giveOrder;
    [Tooltip("this is just here so you dont  for get to click in the disstenceTimer")]
    public disstenceTimer timedQestLocation;
    public compass MainQest;

    void Update()
    {
        if (giveOrder == true)
        {
            if (Orders[Number].fancyLoad == true)
            {
                Orders[Number].flashyLoad();
            }

            if (Orders[Number].fancyLoad == false)
            {
                Orders[Number].GiveItems();

            }
            if (Orders[Number].timedQest == true)
            {
                timedQestLocation.buffer = 0;
                timedQestLocation.End = Orders[Number].theLocation;
                if (Orders[Number].removeTime == false)
                {
                    timedQestLocation.buffer += Orders[Number].ExtraTime;
                }
                if (Orders[Number].removeTime == true)
                {
                    timedQestLocation.buffer -= Orders[Number].ExtraTime;
                }
                timedQestLocation.startQest();

            }
            giveOrder = false;
        }
    }
    public void OrdersGiven()
    {
        StartCoroutine(giveTheOrder());
    }
    IEnumerator giveTheOrder()
    {
        yield return new WaitForSeconds(1);
        giveOrder = true;
    }

}
