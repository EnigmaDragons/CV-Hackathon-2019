using UnityEngine;
using TMPro;

public class MoneyScoreCalculators 
{
	// Game Score
	private int _gameScore => GameState.Current.GameScore;

	// Multipliers
	private int _level => GameState.Current.Level;
	private int _numServed => GameState.Current.NumCustomersServed;
	private int _stars => GameState.Current.StarRatings;

	public int CarValue = 200;

	// private functions

	private int CalculateAddMoneyValue() {
		var gameplayX = 1*_level;
		var cashX = 1*CarValue*_stars;

		var money = gameplayX*cashX;
		return money;
	}

	private int CalculateRemoveMoneyValue() {
		var gameplayX = 1*_level;
		var cashX = 1*CarValue;

		var money = gameplayX*cashX;
		return money;
	}

	// public functions

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
