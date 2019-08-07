using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaulerPlayerScript : MonoBehaviour
{


	public GameObject Hauler;
	
	// start in middle lane (0,1,2)
	private int currentLane = 1;
	private GameObject[] Cars;

	void StartGame()
	{
		// init game world
		// init hauler player
		// init controller

		currentLane = 1;	
	}

	private void SpawnCar()
	{
		var carPrototype = Cars[0];
		Instantiate(carPrototype, new Vector3(100, 400, 0), Quaternion.identity);
	}

	private void UpButton()
	{
		// Up arrow button action
		if (currentLane > 0)
		{
			currentLane -= 1;
		}
	}

	private void DownButton()
	{
		// Down arrow button action
		if (currentLane < 2)
		{
			currentLane += 1;
		}
	}

	private void ActionButton()
	{
		SpawnCar();
		// shoot car down lane
	}

	private void RunGame()
	{

		// Up arrow button action
		if (Input.GetButton("Up"))
		{
			UpButton();
		}

		// Down arrow button action
		if (Input.GetButton("Down"))
		{
			DownButton();
		}

		// Spacebar action
		if (Input.GetButton("Space"))
		{
			ActionButton();
		}

	}


    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        RunGame();
    }
}
