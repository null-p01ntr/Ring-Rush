using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DelayedStart : MonoBehaviour
{
	static public bool GameStarted;
	//public Sprite[] nums;
	//int num;
	void Start()
	{
		GameStarted = false;
		gameObject.GetComponent<Animator>().Play("countdown");
		StartCoroutine("Start_Delay");
	}
	IEnumerator Start_Delay()
	{
		Time.timeScale = 0f;
		float pauseTime = Time.realtimeSinceStartup + 3f;
		while (Time.realtimeSinceStartup < pauseTime)
		{
			//num = (int)(pauseTime - Time.realtimeSinceStartup);
			//gameObject.GetComponent<Image>().sprite = nums[num];
			yield return 0;
		}
		GameStarted = true;
		Time.timeScale = 1f;
		gameObject.SetActive(false);
	}
}
