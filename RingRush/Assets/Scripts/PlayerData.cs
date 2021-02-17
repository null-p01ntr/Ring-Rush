using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
	public string pName;
	public int score;

	public PlayerData(EnterName player)
	{
		pName = player.pName;
		score = player.score;
	}
}
