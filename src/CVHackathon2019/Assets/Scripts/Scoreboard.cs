using UnityEngine;

public class Scoreboard : MonoBehaviour
{
	public GUIText scoreText;
	private int score;
	
	void Start ()
	{
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
