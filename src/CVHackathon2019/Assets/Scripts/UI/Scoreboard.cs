using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{

	public TextMeshProUGUI scoreText;
	public int score;

	private int _gameScore => GameState.Current.GameScore;
	
	void Start ()
	{
		scoreText = GetComponent<TextMeshProUGUI>();
	    score = _gameScore;
	}

	void Update ()
	{
		score = _gameScore;
	    GameState.Current.GameScore = score;
	    scoreText.text = "$" + score;
	}

}
