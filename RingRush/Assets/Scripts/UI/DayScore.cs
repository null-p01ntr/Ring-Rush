using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class DayScore : MonoBehaviour
{
    public Text scoreT;
    public Text day;
    public GameObject nextDayButton;
    public int timeLeft;
    public bool takingAway = false;

    void Start()
    {
        DelayedStart.GameStarted = false;
        timeLeft = 3;
        nextDayButton.SetActive(false);
        scoreT.text = Score.score.ToString();
        day.text = Timer.dayCount.ToString();
		Score.totalScore += Score.score;
	}
    void Update()
    {
        if (takingAway == false && timeLeft > 0)
            StartCoroutine(TimerTake());
        else if (timeLeft == 0)
            nextDayButton.SetActive(true);
    }
    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        timeLeft--;
        takingAway = false;
    }
}
