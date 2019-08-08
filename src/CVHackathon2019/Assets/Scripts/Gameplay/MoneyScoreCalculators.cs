using UnityEngine;
using TMPro;

public class MoneyScoreCalculators 
{
	public int score;

	private int _gameScore => GameState.Current.GameScore;

	// multipliers
	public int Difficulty = 1;
	public int Level = 1;

	private int _numServed => GameState.Current.NumCustomersServed;
	private int _stars => GameState.Current.StarRatings;


	public int CarDeliveredCashValue = 1000;


	// in progress, global state vars, etc
	public int CalculateScore() {
		var curScore = score;

		var gameplayMultipliers = 1*Level*Difficulty;
		var cashMultipliers = 1*CarDeliveredCashValue*_stars;
		var multipliers = gameplayMultipliers*cashMultipliers;

		var newScore = _numServed*(1*multipliers);

		var scoreCalc = newScore;
		return scoreCalc;
	}

}
