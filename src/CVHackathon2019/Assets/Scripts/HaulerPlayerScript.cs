using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HaulerPlayerScript : MonoBehaviour
{

	public float timeBetweenMovement = 0.05f;
	public GameObject Hauler;

	public GameObject Lanes;
	private Transform[] LanePositions => Lanes.transform.OfType<Transform>().Select(x => x).ToArray();
	
	// start in middle lane (0,1,2)
	private int currentLane = 1;
	public GameObject Cars;

	void StartGame()
	{
		// init game world
		// init hauler player
		// init controller

		currentLane = 1;	
	}

	private void SpawnCar()
	{
		var carPrototype = Cars;
		Instantiate(carPrototype, new Vector3(-3, 0, 0), Quaternion.identity);
	}

	private void UpButton()
	{
		// Up arrow button action
		if (currentLane > 0)
		{
			currentLane -= 1;
		}
		UpdatePosition();
	}

	private void DownButton()
	{
		// Down arrow button action
		if (currentLane < 2)
		{
			currentLane += 1;
		}
		UpdatePosition();

	}

	private void UpdatePosition()
	{
		transform.position = new Vector3(transform.position.x, LanePositions[currentLane].position.y, 0);
		Debug.Log("Lane = " + currentLane);
	}
	
	private void ActionButton()
	{
		SpawnCar();
		// shoot car down lane

		Debug.Log("Spawn a car!");
	}

	private IEnumerator RunGame()
	{
		while(true) {

			// Up arrow button action
			if (Input.GetAxis("Vertical") > 0)
			{
				UpButton();
				yield return new WaitForSeconds(timeBetweenMovement);
			}

			// Down arrow button action
			else if (Input.GetAxis("Vertical") < 0)
			{
				DownButton();
				yield return new WaitForSeconds(timeBetweenMovement);
			}

			// Spacebar action
			else if (Input.GetButton("Jump"))
			{
				ActionButton();
				yield return new WaitForSeconds(timeBetweenMovement*3);
			}

			else 
			{
				yield return new WaitForSeconds(timeBetweenMovement);
			}

		}

	}


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunGame());
    }

    // Update is called once per frame
    // void Update()
    // {
    //     RunGame();
    // }
}
