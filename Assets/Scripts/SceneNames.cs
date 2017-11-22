using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNames : MonoBehaviour
{
    public static string MainMenu = "MenuTest";
    public static string LoadingScreen = "LoadingScreen";
    public static string Level01 = "Level_01";
    public static string Level02 = "Level_02";
    public static string Level03 = "Level_03";

    public static bool loading = false;
    public static string sceneToLoad;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public static void LoadScene(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(LoadingScreen);
        sceneToLoad = name;
        loading = true;
    }
}
