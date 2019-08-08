using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HaulerInputHandler : MonoBehaviour
{
    public float inputDelaySeconds = 0.025f;
    public float secondsBetweenMovement = 0.5f;
    public float secondsBetweenLaunching = 1.0f;
    public bool canHoldMoveKey = false;
    public GameObject Hauler;

    public GameObject Lanes;
    private Transform[] LanePositions => Lanes.transform.OfType<Transform>().Select(x => x).ToArray();

    // start in middle lane (0,1,2)
    private int currentLane = 1;

    // Input tracking
    private float _timer;
    private float _lastMovementTime;
    private float _lastLaunchTime;
    private bool _releasedKey = true;
    
    // audio
    public AudioSource AudioSource;
    public AudioClip CarLaunched;
    public AudioClip HaulerMoved;

    // car spawner
    public CarSpawner myCarSpawner;

    private void MoveUp()
    {
        // Up arrow button action
        if (currentLane > 0)
            currentLane -= 1;

        UpdatePosition();
    }

    private void MoveDown()
    {
        // Down arrow button action
        if (currentLane < 2)
            currentLane += 1;

        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position = new Vector3(transform.position.x, LanePositions[currentLane].position.y, 0);

        AudioSource.PlayOneShot(HaulerMoved);
        Debug.Log("Lane = " + currentLane);
    }

    private void LaunchCar()
    {
        myCarSpawner.LaunchCar();
        Debug.Log("Launch a car!");
    }

    private IEnumerator RunGame()
    {
        while (true)
        {
            if (!_releasedKey && Input.GetAxis("Vertical") == 0)
                _releasedKey = true;
            
            if (Input.GetAxis("Vertical") > 0 && CanMove())
            {
                MoveUp();
                _lastMovementTime = _timer;
                _releasedKey = false;
            }
            else if (Input.GetAxis("Vertical") < 0 && CanMove())
            {
                MoveDown();
                _lastMovementTime = _timer;
                _releasedKey = false;
            }
            else if (Input.GetButton("Jump") && CanLaunch())
            {
                LaunchCar();
                _lastLaunchTime = _timer;
            }

            yield return new WaitForSeconds(inputDelaySeconds);
        }
    }

    private bool CanLaunch()
    {
        return _timer - _lastLaunchTime >= secondsBetweenLaunching;
    }

    private bool CanMove()
    {
        return (canHoldMoveKey || !canHoldMoveKey && _releasedKey) && _timer - _lastMovementTime >= secondsBetweenMovement;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunGame());
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
    }
}