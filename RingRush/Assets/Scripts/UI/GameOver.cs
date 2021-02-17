using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text scoreT;
	public AudioSource main;
	public AudioSource gameover;

    private void Start()
    {
        DelayedStart.GameStarted = false;
        Time.timeScale = 0f;
		Score.totalScore = Score.totalScore * Timer.dayCount;
		scoreT.text = Score.totalScore.ToString();
		main.Stop();
		gameover.mute = main.mute;
		gameover.Play();
    }
}
