using System.IO;
using System.Collections.Generic;
using UnityEngine;
public class SaveData
{
	public static void SaveScore(EnterName player)
	{
		string path = Application.persistentDataPath + "/scores.json";
		PlayerData data = new PlayerData(player);

		File.AppendAllText(path, data.pName + ":" + data.score.ToString() + ":");
	}
}
