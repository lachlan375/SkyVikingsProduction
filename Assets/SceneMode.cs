using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMode : MonoBehaviour
{
    public GameObject modeUIRef;
    public LevelManagment lvlManageRef;
	public bool bossMode_available;


    //Test Functionality in Update
    public bool testCall;
    //    public int sceneMode;

    public int level_mode = 0;

    // Use this for initialization
    void Start()
    {
        lvlManageRef = gameObject.GetComponent<LevelManagment>();
        sceneMode_Check(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (testCall == true)
        {
            sceneMode_Check(level_mode);
            testCall = false;
        }
        /*if (level_mode == 4)
        {
            if (Input.GetKey(KeyCode.P))
            {
                Time.timeScale = 1;
                lvlManageRef.MainMenu();
            }
        }*/
    }

    public void sceneMode_Check(int modeRef)
    {

        level_mode = modeRef;
        switch (level_mode)
        {
            case 4:
                //Time.timeScale = 0;
                modeUIRef.GetComponent<ModeUI>().GameUI_End();
                //lvlManageRef.MainMenu();

                break;
			case 3:
				bossMode_available = false;
                lvlManageRef.NextLevel();
                break;
		case 2:
				bossMode_available = true;
				modeUIRef.GetComponent<ModeUI>().BossUI_Start();
                break;
			case 1:
				modeUIRef.GetComponent<ModeUI> ().LevelUI_Cont();
				break;

            default:
				bossMode_available = false;
				modeUIRef.GetComponent<ModeUI>().LevelUI_Start();

                level_mode++;
                break;
        }

    }
}
