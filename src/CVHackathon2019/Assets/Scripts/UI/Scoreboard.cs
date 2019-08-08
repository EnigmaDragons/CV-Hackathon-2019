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
	    scoreText.text = "$" + score;
	}

	void Update ()
	{
		score = 1000*GameState.Current.NumCustomersServed;
	    UpdateScore ();
	}

}
