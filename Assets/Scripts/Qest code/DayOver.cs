using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DayOver : MonoBehaviour {
    
    public Text [] thetext;
     public int couter;
    public GameObject []  nextAndBack;
    public string nubers;
    public ObjectPriceList price;
    public int score;
    private int box;
    public GameObject ui;
    public sunAndmoon sunDown;
    public bool dayover;

    public playerStats stats;
    public LevelManagment lvlManagerRef;
    public SceneMode scnModeRef;
    public HQSceneActivation hqSceneRef;

	public int dayCountRef;
    // Use this for initialization


    void Start()
    {
        scnModeRef = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneMode>();
        lvlManagerRef = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<LevelManagment>();
        hqSceneRef = GameObject.FindGameObjectWithTag("HQCamera").GetComponent<HQSceneActivation>();

		dayCountRef = GameObject.FindGameObjectWithTag ("SceneManager").GetComponent<LevelManagment> ().dayCount;
    }
    void OnEnable()
    {

    }
        // Update is called once per frame
    void Update () {
		
	}
    public void cargo()
    {
    
        
     }
    public void dayOver()
    {
 
 
    }
    public void ANewday()
    {
        int modeRef;
        //status check
        if (stats.respectScore > lvlManagerRef.unlock_BossMode[lvlManagerRef.currentlevelInt])
        {
            modeRef = 2;
        }
        else
        {
            modeRef = 1;
        }
        Time.timeScale = 1;
		dayCountRef++;
		lvlManagerRef.dayCount = dayCountRef;

        gameObject.SetActive(false);
        scnModeRef.sceneMode_Check(modeRef);
        //hqSceneRef.HQRelease();

    }
    public void back()
    {
      

    }
}
