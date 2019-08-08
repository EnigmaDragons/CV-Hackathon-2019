using UnityEngine;
using TMPro;

public class MoneyScoreCalculators 
{
	public int score;

	private int _gameScore => GameState.Current.GameScore;

	// multipliers
	// private int _difficulty = ...
	private int _level => GameState.Current.Level;
	private int _numServed => GameState.Current.NumCustomersServed;
	private int _stars => GameState.Current.StarRatings;

	public int CarDeliveredCashValue = 1000;

	// Calculate Car value (WIP)
	public int CalculateAddMoneyValue() {
		var gameplayMultipliers = 1*_level;//*difficulty
		var cashMultipliers = 1*CarDeliveredCashValue*_stars;
		var multipliers = gameplayMultipliers*cashMultipliers;

		var newScore = 1*(1*multipliers);

		return newScore;
	}

	public int CalculateRemoveMoneyValue() {
		var gameplayMultipliers = 1*_level;//*difficulty
		var cashMultipliers = 1*CarDeliveredCashValue*1;
		var multipliers = gameplayMultipliers*cashMultipliers;

		var newScore = 1*(1*multipliers);

		return newScore;
	}

	public void PlusMoneyCarDelivered() {
		var carValue = CalculateAddMoneyValue();

		GameState.Current.GameScore += carValue;
	}

	public void MinusMoneyCarsCrash() {
		var carValue = CalculateRemoveMoneyValue();
		var twoCarsValue = (carValue*2);

		GameState.Current.GameScore -= twoCarsValue;
	}



}
