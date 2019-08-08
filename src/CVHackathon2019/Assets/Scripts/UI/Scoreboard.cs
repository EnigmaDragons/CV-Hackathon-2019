using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{

	public TextMeshProUGUI scoreText;
	public int score;

	private int _gameScore => GameState.Current.GameScore;

	// multipliers
	public int Difficulty = 1;
	public int Level = 1;

	private int _numServed => GameState.Current.NumCustomersServed;
	private int _stars => GameState.Current.StarRatings;


	public int CarDeliveredCashValue = 1000;

	void Start ()
	{
		scoreText = GetComponent<TextMeshProUGUI>();
	    score = _gameScore;
	    UpdateScore ();
	}

	// in progress, global state vars, etc
	int CalculateScore() {
		var curScore = score;

		var gameplayMultipliers = 1*Level*Difficulty;
		var cashMultipliers = 1*CarDeliveredCashValue*_stars;
		var multipliers = gameplayMultipliers*cashMultipliers;

		var newScore = 1*multipliers*_numServed;

		var scoreCalc = newScore;
		return scoreCalc;
	}

	void UpdateScore ()
	{
		GameState.Current.GameScore = score;
	    scoreText.text = "$" + score;
	}

	void Update ()
	{
		score = CalculateScore();
	    UpdateScore ();
	}

}
