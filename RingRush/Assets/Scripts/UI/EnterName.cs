using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterName : MonoBehaviour
{
    public InputField uName;
    public Sprite notEmpty;
    public GameObject err;

	public int score;
	public string pName;

    private void Update()
    {
        uName.text = uName.text.ToUpper();
        if (uName.text!="")
        {
            uName.image.sprite=notEmpty;
        }
    }

    public void Scene_Loader(string SceneName)
    {
		if (uName.text != "")
		{
			pName = uName.text;
			score = Score.totalScore;
			SaveData.SaveScore(this);
			Score.totalScore = 0;
			Timer.dayCount = 0;
			SceneManager.LoadScene(SceneName);
		}
		else uName.image.color=new Color32(226, 6, 19, 255);
    }
}
