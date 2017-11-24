using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public int index;
    public bool is_ActiveHQMode;        //flag to check if HQ Mode is active
                                        // Use this for initialization
    public SceneTransistion sceneTransitRef;

    public int newGame = 2;

    public Image black;
    public Animator anim;
                                            
    void Start ()
    {

        sceneTransitRef = gameObject.GetComponent<SceneTransistion>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGame()
    {
        StartCoroutine(Fading());
        //SceneNames.LoadScene("LoadingScreen");
    }

        public void Exit()
    {
        Application.Quit();
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a >= .90);
        anim.SetBool("isfadeing", true);
        //yield return new WaitUntil(() => black.color.a == 0);
        SceneNames.LoadScene("level1Integration");
    }

}
