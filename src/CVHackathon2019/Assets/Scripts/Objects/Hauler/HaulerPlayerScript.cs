using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HaulerPlayerScript : MonoBehaviour
{
    public float inputDelaySeconds = 0.025f;
    public float secondsBetweenMovement = 0.5f;
    public float secondsBetweenLaunching = 1.0f;
    public float secondsToLoadCar = 1.6f;
    public bool hasCarLoaded = false;
    public bool canMove = false;

    public float CarDriveSpeed = 137;
    public float DriveSpeed = 4500;
    private Rigidbody2D _rigidbody;
    public GameObject Lanes;
    private Transform[] LanePositions => Lanes.transform.OfType<Transform>().Select(x => x).ToArray();

    // start in middle lane (0,1,2)
    private int currentLane = 1;

    // Input tracking
    private float _timer;
    private float _lastMovementTime;
    private float _lastActionTime;
    private bool _releasedKey = true;
    
    // audio
    public AudioSource AudioSource;
    public AudioClip CarLaunched;
    public AudioClip HaulerMoved;

    // car spawner
    public CarSpawner myCarSpawner;
    private GameObject _maybeLoadedCar;

    private void MoveUp()
    {
        _lastMovementTime = _timer;
        _releasedKey = false;
        // Up arrow button action
        if (currentLane > 0)
            currentLane -= 1;

        UpdatePosition();
    }

    private void MoveDown()
    {
        _lastMovementTime = _timer;
        _releasedKey = false;
        
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
        hasCarLoaded = false;
        _maybeLoadedCar.transform.parent = null;
        _maybeLoadedCar.AddComponent<Rigidbody2D>();
        _maybeLoadedCar.GetComponent<Rigidbody2D>().AddForce(-transform.right * CarDriveSpeed);
        _maybeLoadedCar = null;
        Debug.Log("Launch a car!");
    }

    private IEnumerator RunGame()
    {
        while (true)
        {
            if (!_releasedKey && Input.GetAxis("Vertical") == 0)
                _releasedKey = true;
            
            if (Input.GetAxis("Vertical") > 0 && CanMove)
                MoveUp();
            else if (Input.GetAxis("Vertical") < 0 && CanMove)
                MoveDown();
            else if (Input.GetButton("Jump"))
            {
                PerformAction();
            }

            yield return new WaitForSeconds(inputDelaySeconds);
        }
    }

    private void OnCollisionEnter(Collision other) => HandleCollision(other.gameObject);
    private void OnCollisionEnter2D(Collision2D other) => HandleCollision(other.gameObject);
    private void OnTriggerEnter(Collider other) => HandleCollision(other.gameObject);
    private void OnTriggerEnter2D(Collider2D other) => HandleCollision(other.gameObject);

    private void HandleCollision(GameObject other)
    {
        const int carLayer = 8;
        if (other.layer == carLayer)
            OnCarCollide(other);
    }

    private void OnCarCollide(GameObject other)
    {
        var car = other.GetComponent<MovingCar>();
        if (!car.IsReturn) return;

        Destroy(other);
    }

    private void PerformAction()
    {
        if (CanLaunch)
        {
            LaunchCar();
            _lastActionTime = _timer;
        }
        else if (CanLoadCar)
        {
            StartCoroutine(LoadCard());
            _lastActionTime = _timer;
        }
    }

    private IEnumerator LoadCard()
    {
        Debug.Log("Began loading car");
        _rigidbody.AddForce(transform.right * DriveSpeed);
        yield return new WaitForSeconds(secondsToLoadCar / 2);
        _maybeLoadedCar = myCarSpawner.LoadCar(this);
        _rigidbody.AddForce(-transform.right * DriveSpeed * 2);
        yield return new WaitForSeconds(secondsToLoadCar / 2);
        _rigidbody.AddForce(transform.right * DriveSpeed);
        hasCarLoaded = true;
        Debug.Log("Finished loading car");
    }

    private bool CanLoadCar => !HasCarOnHauler && _timer - _lastActionTime >= secondsToLoadCar;
    private bool HasCarOnHauler => hasCarLoaded;

    private bool CanLaunch => HasCarOnHauler && _timer - _lastActionTime >= secondsBetweenLaunching;
 
    private bool CanMove => (canMove || !canMove && _releasedKey) && _timer - _lastMovementTime >= secondsBetweenMovement;

    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(RunGame());
    }

    void Update()
    {
        _timer += Time.deltaTime;
    }
}
