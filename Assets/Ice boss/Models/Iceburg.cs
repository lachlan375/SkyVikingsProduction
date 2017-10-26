using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceburg : MonoBehaviour {
    private GameObject player;
    public Transform pathholder;
    public float waittime = .3f;
    public float Speed = 5f;
    public bool walking;
    public int targetWayponitIndex;
    public float TurnSpeed;
    [Header("ice block")]
    public GameObject theIceBlock;
    public float IceSpeed;
    public YetiControler Yeti;
    public bool ISnotSpining;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3[] wayponits = new Vector3[pathholder.childCount];
        for (int i = 0; i < wayponits.Length; i++)
        {
            wayponits[i] = pathholder.GetChild(i).position;
        }
        StartCoroutine(FollowPath(wayponits));
        transform.LookAt(wayponits[0]);

    }

    IEnumerator FollowPath(Vector3[] wayponits)
    {
        transform.position = wayponits[0];

        Vector3 targetWayponit = wayponits[targetWayponitIndex];
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWayponit, Speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetWayponit) < 1)
            {
                Yeti.throwball();
                transform.LookAt(player.transform.position);
                ISnotSpining = true;
                targetWayponitIndex = (targetWayponitIndex + 1) % wayponits.Length;
                targetWayponit = wayponits[targetWayponitIndex];
                yield return new WaitForSeconds(waittime);
                transform.LookAt(targetWayponit);
            }
            yield return null;
            ISnotSpining = false;
        }

    }


    void Update()
    {
        if(ISnotSpining == false)
        {
        transform.Rotate(0, IceSpeed, 0);
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Vector3 startPositoin = pathholder.GetChild(0).position;
        Vector3 Lastposition = startPositoin;
        foreach (Transform waypoint in pathholder)
        {
            Gizmos.DrawSphere(waypoint.position, 0.3f);
            Gizmos.DrawLine(Lastposition, waypoint.position);
            Lastposition = waypoint.position;
        }


    }
}
