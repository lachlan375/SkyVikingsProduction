using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenTransition : MonoBehaviour {

    public GameObject cv01, cv02, cv03;

	void Start () {
        if (SceneNames.sceneToLoad == "Level_01")
            cv01.SetActive(true);
        else if (SceneNames.sceneToLoad == "Level_02")
            cv02.SetActive(true);
        else if (SceneNames.sceneToLoad == "Level_03")
            cv03.SetActive(true);

        if (SceneNames.loading)
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneNames.sceneToLoad);
        SceneNames.loading = false;
        SceneNames.sceneToLoad = "";
    }

    //AsyncOperation async;

    //// Use this for initialization
    //void Start()
    //{
    //    if (SceneNames.loading)
    //        StartCoroutine(Load());
    //}

    //IEnumerator Load()
    //{
    //    async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneNames.sceneToLoad);
    //    async.allowSceneActivation = false;
    //    yield return async;
    //}

    //void Update()
    //{
    //    if (async.isDone)
    //    {
    //        async.allowSceneActivation = true;
    //        SceneNames.loading = false;
    //        SceneNames.sceneToLoad = "";
    //    }
    //}
}
