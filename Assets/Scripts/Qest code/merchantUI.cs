using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class merchantUI : MonoBehaviour {
    public postmaster ThePostMaster;
    public Text[] falvorText;
    public Text[] merchantText;
    public GameObject[] buttons;
    public Image panel;
    private int maxQests;
    [HideInInspector]
    public Font[] fonts = new Font[2];
    public int OrderNumber;
    public disstenceTimer qeststart;
    public bool open;
    // Use this for initialization
    void OnEnable()
    {
        open = true;
        panel.sprite = ThePostMaster.PostmaterBackground;
        fonts[0] = ThePostMaster.postMasterHeader;
        fonts[1] = ThePostMaster.postMasterText;
        falvorText[0].font = fonts[0];
        falvorText[1].font = fonts[0];

        falvorText[0].text = ThePostMaster.PostMastrsName;
        falvorText[1].text = ThePostMaster.Desciption;
        for (int i = 0; i < merchantText.Length; ++i)
        {
            merchantText[i].text = "";
            buttons[i].SetActive(i < ThePostMaster.Orders.Length);

            if (i < ThePostMaster.Orders.Length)
            {
                buttons[i].GetComponentInChildren<Text>().font = fonts[1];

                merchantText[i].font = fonts[1];
                merchantText[i].text = "Cargo:" + ThePostMaster.Orders[i].QestCard[0].CargoName + "\n" + "Vaule:" + ThePostMaster.Orders[i].QestCard[0].value + " \n" + "Info: " + ThePostMaster.Orders[i].QestCard[0].CargoDescription + " \n" + "Deliver to:" + ThePostMaster.Orders[i].theLocation.name;
            }

        }
       // go();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void go()
    {
        ThePostMaster.Number = 0;
        ThePostMaster.OrdersGiven();
        qeststart.qestStart = true;
        gameObject.SetActive(false);
    }
   
    public void buttonDOAthing(int QestNumber)
    {
        Debug.Log("beep");
        ThePostMaster.Number = QestNumber;
         ThePostMaster.OrdersGiven();
         qeststart.qestStart = true;
          gameObject.SetActive(false);
        

    }

}

