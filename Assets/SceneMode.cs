using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMode : MonoBehaviour {
	public int sceneMode;

	public int level_mode = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void sceneMode_Check()
	{

            switch (sceneMode)
            {
                case 2:
                    print("Boss Mode!!!");
                    break;
                case 1:
                    print("Normal Everyday Level - Ongoing");
                    break;
                default:
                    print("Starting New Level");
                    sceneMode++;
                    break;
            }
           
        }
}
