using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    AsyncOperation gameLoading;
    public static float progress;
    public void Loading(string curr_scene)
    {
        SceneManager.LoadSceneAsync("Loading", LoadSceneMode.Additive);
        gameLoading = SceneManager.LoadSceneAsync("InGame", LoadSceneMode.Additive);

        StartCoroutine(GetGameLoad(curr_scene));
    }
    public IEnumerator GetGameLoad(string curr_scene)
    {
        while (!gameLoading.isDone)
        {
            progress = Mathf.Clamp01(gameLoading.progress / 0.9f);
            yield return null;
        }
        SceneManager.UnloadSceneAsync(curr_scene);
        SceneManager.UnloadSceneAsync("Loading");
    }
}
