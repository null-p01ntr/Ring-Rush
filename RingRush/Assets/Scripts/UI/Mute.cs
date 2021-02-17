using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    //public AudioSource music;

    Image img;
    public Sprite on;
    public Sprite off;

	private void Start()
	{
		img = gameObject.GetComponent<Image>();
	}
    
    public void Muted()
    {
        AudioListener.pause = !AudioListener.pause;
    }

	void Update()
    {
        /*if (Input.GetKeyDown("m"))
            music.mute = !music.mute;

        if (music.mute)
            img.sprite = off;
        else img.sprite = on;*/

        if (Input.GetKeyDown("m"))
            Muted(); 

        if (AudioListener.pause)
            img.sprite = off;
        else img.sprite = on;
    }
}
