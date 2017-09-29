using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skilltreeButton : MonoBehaviour {
    [HideInInspector]
    public Button TheButton;
    public skilltree theSkillTree;
    public int ID;
    // Use this for initialization
    void Start () {
        TheButton = gameObject.GetComponent<Button>();
        TheButton.onClick.AddListener(OnButtonClick);

    }
    void OnButtonClick()
    {
        theSkillTree.addStats(ID);
        Debug.Log("hit");
    }


}
