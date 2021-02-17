using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadProgress : MonoBehaviour
{
    public Slider progressBar;

    void Update()
    {
        progressBar.value = LoadGame.progress;
    }
}
