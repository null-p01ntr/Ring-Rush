using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timer;
	public Font altFont;
	static public int timeLeft;
    public bool takingAway = false;

    static public int dayCount = 0;

    private void Start()
    {
		timeLeft = 120;
	}
	private void Update()
	{
		if (takingAway == false && timeLeft > 0)
			StartCoroutine(TimerTake());
		else if (timeLeft == 0)
			DayOver();

		if (Ring.ea)
		{
			timer.font = altFont;
			timer.fontSize = 55;
		}
	}
    IEnumerator TimerTake()
    {
        string mid;
        takingAway = true;
        yield return new WaitForSeconds(1);
        timeLeft--;

        if (timeLeft >= 60)
        {
            if (timeLeft - 60 < 10)
                mid = ":0";
            else mid = ":";

            timer.text = "0" + (timeLeft / 60).ToString() + mid + (timeLeft - 60).ToString();
        }
        else
        {
            if (timeLeft < 10)
                mid = ":0";
            else mid = ":";

            timer.text = "00" + mid + timeLeft.ToString();
        }
        takingAway = false;
    }

    public void DayOver()
    {
        dayCount++;
        SceneManager.LoadScene("NextDay");
    }
}
