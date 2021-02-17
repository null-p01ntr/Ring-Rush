using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedCamera : MonoBehaviour
{
	public AudioSource music;
	public GameObject countdown;

	private void Start()
	{
		Time.timeScale = 0f;
	}

	void Animation_State(int animFinished)
	{
		if (animFinished == 1)
		{
			music.Play();
			countdown.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}
