using System.Globalization;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
	public TextMeshProUGUI scoreText;
	
	void Start ()
	{
		scoreText = GetComponent<TextMeshProUGUI>();
	}

	void Update ()
	{
	    scoreText.text = string.Format(CultureInfo.InvariantCulture, "{0:N0}", GameState.Current.GameScore);
	}
}
