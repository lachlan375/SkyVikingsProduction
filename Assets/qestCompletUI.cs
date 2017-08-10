using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qestCompletUI : MonoBehaviour {
    [HideInInspector]
    public qestComplet qestM;
    public GameObject end;

    public void theQest(bool newQuest)
    {
        if (newQuest == true)
        {
            Time.timeScale = 0;
            qestM.startQest();
            gameObject.SetActive(false);
        }
        if (newQuest == false)
        {
            gameObject.SetActive(false);
        }
    }
    public void dayover()
    {
        Debug.Log("the days over");
        end.SetActive(true);
        gameObject.SetActive(false);
    }

}
