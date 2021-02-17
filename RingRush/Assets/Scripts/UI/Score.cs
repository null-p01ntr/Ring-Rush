using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreT;
	public Font altFont;
    static public int score;
    static public int totalScore;
    void Start()
    {
		if (Timer.dayCount == 0)
			totalScore = 0;
		score = 0;
    }
    void Update()
    { 
        scoreT.text = score.ToString();
		if (Ring.ea)
			scoreT.font = altFont;
    }
}
