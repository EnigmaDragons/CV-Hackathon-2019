using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public GUIText scoreText;
private int score;

public class OnLevelComplete : MonoBehaviour
{

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
