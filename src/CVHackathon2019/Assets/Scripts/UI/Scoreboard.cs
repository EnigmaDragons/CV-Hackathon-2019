using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{

	public TextMeshProUGUI scoreText;
	public int score;

	private int _gameScore => GameState.Current.GameScore;

	public MoneyScoreCalculators MoneyScoreCalculators = new MoneyScoreCalculators();

	void Start ()
	{
		scoreText = GetComponent<TextMeshProUGUI>();
	    score = _gameScore;
	}

	void Update ()
	{
		score = _gameScore;
		score = MoneyScoreCalculators.CalculateScore();

	    GameState.Current.GameScore = score;
	    scoreText.text = "$" + score;
	}

}
