using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{

	public TextMeshProUGUI scoreText;
	private int score;

	void Start ()
	{
		scoreText = GetComponent<TextMeshProUGUI>();
	    score = 0;
	    UpdateScore ();
	}

	void UpdateScore ()
	{
	    scoreText.text = "Score: " + score;
	}

	void Update ()
	{
		score = GameState.Current.NumCustomersServed;
	    UpdateScore ();
	}

}
