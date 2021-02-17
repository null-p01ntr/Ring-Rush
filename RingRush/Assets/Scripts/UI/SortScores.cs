using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortScores : MonoBehaviour
{
	public Text names;
	public Text scores;

	private void Start()
	{
		string read = File.ReadAllText(Application.persistentDataPath + "/scores.json");
		string[] array = read.Split(':');

		int[] Scores = new int[array.Length/2];
		string[] Names = new string[array.Length/2];
		int j = 0;
		for (int i = 0; i < array.Length-1; i += 2)
		{
			Names[j] = array[i];
			Scores[j] = Int16.Parse(array[i + 1]);
			j++;
		}
		Array.Sort(Scores, Names);

		for (int i = array.Length / 2 - 1; i >= 0; i--)
		{
			scores.text += Scores[i].ToString() + "\n";
			names.text += Names[i] + "\n";
		}
	}
}
