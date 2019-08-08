using UnityEngine;
using TMPro;

public class MoneyScoreCalculators 
{
	public int score;

	private int _gameScore => GameState.Current.GameScore;

	// multipliers
	private int _level => GameState.Current.Level;
	private int _numServed => GameState.Current.NumCustomersServed;
	private int _stars => GameState.Current.StarRatings;

	public int CarDeliveredCashValue = 1000;

	public int CalculateMoneyValue() {
		var gameplayMultipliers = 1*_level;
		var cashMultipliers = 1*CarDeliveredCashValue*_stars;
		var multipliers = gameplayMultipliers*cashMultipliers;

		var newScore = 1*(1*multipliers);

		return newScore;
	}

	public void AddValueCarDelivered() {
		var money = CalculateMoneyValue();

		GameState.Current.GameScore += money;
	}

	// in progress, global state vars, etc
	// public int CalculateScore() {
	// 	var curScore = _gameScore;
	// 	score = CalculateMoneyValue();
	// 	var newScore = curScore+score;

	// 	var scoreCalc = newScore;
	// 	return scoreCalc;
	// }

}
