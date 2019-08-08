using System.Collections;
using UnityEngine;
using System.Linq;
using Objects.Hauler;

public class HaulerPlayerScript : MonoBehaviour
{
    public float SecondsToLoadCar = 1.6f;
    public float DriveSpeed = 4500;
    public GameObject Lanes;
    
    public CarSpawner CarSpawner;
    public AudioClips AudioClips;
    public HaulerInputHandler Inputs;

    private int _currentLane = 1;
    private MovingCar _maybeLoadedCar;
    private Rigidbody2D _rigidbody;
    private Vector3 _offset;
    private Transform[] LanePositions => Lanes.transform.OfType<Transform>().Select(x => x).ToArray();
  
    public void Start()
    {
        _offset = gameObject.transform.localPosition;
        _rigidbody = GetComponent<Rigidbody2D>();
        Inputs.Init(this);
        UpdatePosition();
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
            AudioClips.PlayHaulerMoved();
        }

        UpdatePosition();
    }

    private void MoveDown()
    {
        if (_currentLane < 2)
        {
            _currentLane += 1;
            AudioClips.PlayHaulerMoved();
        }

        UpdatePosition();
    }

    private void UpdatePosition()
    {
        var lane = LanePositions[_currentLane];
        transform.position = new Vector3(transform.position.x, lane.position.y + _offset.y, lane.position.z + _offset.z);
        Debug.Log("Lane = " + _currentLane);
    }

    private void LaunchCar()
    {
        AudioClips.PlayCarLaunched();
        _maybeLoadedCar.Launch();
        _maybeLoadedCar = null;
    }

    private void PerformAction()
    {
        if (_maybeLoadedCar != null)
            LaunchCar();
        else if (!IsLoading)
            StartCoroutine(LoadCard());
    }

    private IEnumerator LoadCard()
    {
        Debug.Log("Began loading car");
        IsLoading = true;
        _rigidbody.AddForce(transform.right * DriveSpeed);
        yield return new WaitForSeconds(SecondsToLoadCar / 2);
        _maybeLoadedCar = CarSpawner.LoadCar(this);
        _rigidbody.AddForce(-transform.right * DriveSpeed * 2);
        yield return new WaitForSeconds(SecondsToLoadCar / 2);
        _rigidbody.AddForce(transform.right * DriveSpeed);
        IsLoading = false;
        Debug.Log("Finished loading car");
    }
}
