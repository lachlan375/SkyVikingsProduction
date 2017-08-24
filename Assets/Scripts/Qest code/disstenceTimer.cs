using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disstenceTimer : MonoBehaviour {

    public bool qestStart;
    public GameObject start;
    [HideInInspector]
    public GameObject End;
    public hitBox gole;
    [HideInInspector]
    public ShipStats stats;
    public GameObject clock;
    public Text numberts;
    public float distance;
    public float time;
    private float speed;
    private float naoSeconds;
    private float seconds;
    private float minutes;
    public qestComplet qest;
    [Tooltip("if you want a qest to start turn this on  its on by defalt right now")]
    public bool countdown;
    [Tooltip("addsor removes  a few extra seconds on to the Clock ")]
    public float buffer;
    [Tooltip("just if you think its to eazy and want to remove time")]
    public bool removeTime;
    [HideInInspector]
    public BoatCargo boat;
    public DayOver day;
    // Use this for initialization

    void Start()
    {
        boat = FindObjectOfType<BoatCargo>();
    }
    // Update is called once per frame
    void Update()
    {

        if (qestStart == false)
        {
            clock.SetActive(false);
        }
        if (qestStart == true)
        {
            clock.SetActive(true);
            numberts.text = "Time " + minutes + ":" + seconds + ":" + naoSeconds;

            if (gole.inTheBox == true)
            {
                countdown = false;
                Debug.Log(minutes);
                Debug.Log(time);
                boat.Complet = true;
                qest.finshed();
                qestStart = false;
                Debug.Log("win");
            }

            if (countdown == true)
            {
                naoSeconds += 1;
                if (naoSeconds == 60)
                {
                    seconds += 1;
                    naoSeconds = 0;
                }
                if (seconds == 60)
                {
                    seconds = 0;
                    minutes += 1;
                }
                if (minutes >= time)
                {
                    Debug.Log("lose");
                }
            }
        }
        if (day.dayover == true)
        {
            qestStart = false;
            boat.fail();
        }






    }
    public void distence()
    {
        distance = Vector3.Distance(start.transform.position, End.transform.position);
        time = speed / distance;
        if (removeTime == false)
        {
            time += buffer;
        }
        if (removeTime == true)
        {
            time -= buffer;
        }
        countdown = true;
        qestStart = true;

    }
    public void startQest()
    {
        distance = Vector3.Distance(start.transform.position, End.transform.position);
        speed = stats.maxSpeed / 10;
       distence();
        Debug.Log("the qest is on");
    }
}
