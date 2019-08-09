using System.Collections;
using UnityEngine;
using System.Linq;
using Objects.Hauler;

public class HaulerPlayerScript : MonoBehaviour
{
    public GameObject Lanes;
    public float MinX = 3.4f;
    public float MaxX = 16f;
    public float NewDriveSpeed = 60;
    
    public bool HasCar => _maybeLoadedCar != null;
    public CarSpawner CarSpawner;
    public AudioPlayer _audioPlayer;
    public HaulerInputHandler Inputs;

    private int _currentLane = 1;
    private MovingCar _maybeLoadedCar;
    private Vector3 _offset;
    private Transform[] LanePositions => Lanes.transform.OfType<Transform>().Select(x => x).ToArray();
    private float _velocity;
    
    public void Start()
    {
        _offset = gameObject.transform.localPosition;
        Inputs.Init(this);
        UpdatePosition();
    }

    public void Update()
    {
        var currentVelocity = _velocity;
        var pos = transform.position;
        var newX = pos.x + currentVelocity * 0.1f; 
        transform.position = new Vector3(newX, pos.y, pos.z);
        
        if (IsMoving && pos.x < MinX || pos.x > MaxX)
        {
            SetVelocity(0);

            var clampedX = Mathf.Clamp(newX, MinX, MaxX);
            transform.position = new Vector3(clampedX, pos.y, pos.z);
        }
    }

    private void SetVelocity(float velocity)
    {
        _velocity = velocity;
    }

    public bool IsLoading { get; private set; }

    public void OnInput(HaulerCommands cmd)
    {
        if (cmd == HaulerCommands.MoveUp)
            MoveUp();
        else if (cmd == HaulerCommands.MoveDown)
            MoveDown();
        else if (cmd == HaulerCommands.PerformAction)
            PerformAction();
    }
    
    private void MoveUp()
    {
        if (_currentLane > 0)
        {
            _currentLane -= 1;
            _audioPlayer.PlayHaulerMoved();
        }

        UpdatePosition();
    }

    private void MoveDown()
    {
        if (_currentLane < 2)
        {
            _currentLane += 1;
            _audioPlayer.PlayHaulerMoved();
        }

        UpdatePosition();
    }

    private void UpdatePosition()
    {
        var lane = LanePositions[_currentLane];
        transform.position = new Vector3(transform.position.x, lane.position.y + _offset.y, lane.position.z + _offset.z);
    }

    private void LaunchCar()
    {
        _audioPlayer.PlayCarLaunched();
        _maybeLoadedCar.Launch();
        _maybeLoadedCar = null;
    }

    private void PerformAction()
    {
        if (_maybeLoadedCar != null)
            LaunchCar();
        else if (!IsLoading && !HasCar)
            StartCoroutine(LoadCar());
    }

    private IEnumerator DriveOutOfGarage()
    {
        SetVelocity(-NewDriveSpeed);
        yield return WaitForReachedDestination();
    }

    private IEnumerator DriveIntoGarage()
    {
        SetVelocity(NewDriveSpeed);
        yield return WaitForReachedDestination();
    }

    public void Return(MovingCar car)
    {
        _maybeLoadedCar = car;
        car.SetReturnHandled();
        StartCoroutine(ReturnCarToGarage());
    }
    
    private IEnumerator LoadCar()
    {
        _audioPlayer.PlayHaulerLoaded();
        IsLoading = true;
        
        yield return DriveIntoGarage();
        
        _maybeLoadedCar = CarSpawner.LoadCar(this);
        
        yield return DriveOutOfGarage();
        
        IsLoading = false;
    }

    private IEnumerator WaitForReachedDestination()
    {
        while (IsMoving)
            yield return new WaitForSeconds(0.1f);
    }

    private bool IsMoving => _velocity > 0 || _velocity < 0;

    private IEnumerator ReturnCarToGarage()
    {
        IsLoading = true;
        yield return new WaitForSeconds(0.16f);
        DestroyImmediate(_maybeLoadedCar.GetComponent<Rigidbody2D>());
        DestroyImmediate(_maybeLoadedCar.GetComponent<Collider2D>());
        _maybeLoadedCar.transform.parent = transform;
        
        yield return DriveIntoGarage();
        
        _maybeLoadedCar.transform.parent = null;
        DestroyImmediate(_maybeLoadedCar);
        _maybeLoadedCar = CarSpawner.LoadCar(this);
        
        yield return DriveOutOfGarage();
        
        IsLoading = false;
    }
    
    private void OnCollisionEnter(Collision other) => HandleCollision(other.gameObject);
    private void OnCollisionEnter2D(Collision2D other) => HandleCollision(other.gameObject);
    private void OnTriggerEnter(Collider other) => HandleCollision(other.gameObject);
    private void OnTriggerEnter2D(Collider2D other) => HandleCollision(other.gameObject);

    private void HandleCollision(GameObject o)
    {
        if (o.layer == 14)
        {
            SetVelocity(0);
        }
    }
}
