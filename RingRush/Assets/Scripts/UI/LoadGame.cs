using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    AsyncOperation gameLoading;
    public static float progress;
    public void Loading()
    {
        SceneManager.LoadSceneAsync("Loading", LoadSceneMode.Additive);
        gameLoading = SceneManager.LoadSceneAsync("InGame", LoadSceneMode.Additive);

        StartCoroutine(GetGameLoad());
    }
    public IEnumerator GetGameLoad()
    {
        while (!gameLoading.isDone)
        {
            progress = Mathf.Clamp01(gameLoading.progress / 0.9f);
            print(progress.ToString());
            yield return null;
        }
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.UnloadSceneAsync("Loading");
    }
}
