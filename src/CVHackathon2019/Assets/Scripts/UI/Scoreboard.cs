using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{

	public TextMeshProUGUI scoreText;
	private int score;

	// multipliers
	public int Difficulty = 1;
	public int Level = 1;

	private int _stars => GameState.Current.StarRatings;


	public int CarDeliveredCashValue = 1000;

	void Start ()
	{
		scoreText = GetComponent<TextMeshProUGUI>();
	    score = 0;
	    UpdateScore ();
	}

	void UpdateScore ()
	{
	    scoreText.text = "$" + score;
	}

	// in progress, global state vars, etc
	int CalculateScore() {
		var curScore = score;

		var numServed = GameState.Current.NumCustomersServed;

		var gameplayMultipliers = 1*Level*Difficulty;
		var cashMultipliers = 1*CarDeliveredCashValue*_stars;
		var multipliers = gameplayMultipliers*cashMultipliers;

		var newScore = 1*multipliers*numServed;

		var scoreCalc = newScore;
		return scoreCalc;
	}

	void Update ()
	{
		score = CalculateScore();
	    UpdateScore ();
	}

}
