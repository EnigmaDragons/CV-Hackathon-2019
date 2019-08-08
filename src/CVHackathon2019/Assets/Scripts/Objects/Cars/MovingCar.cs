using UnityEngine;
using Assets.Scripts;

public class MovingCar : MonoBehaviour
{
    public AudioPlayer _audioPlayer;
    public bool IsReturn = false;
    public float CarDriveSpeed = 137;
    public bool NeedsToBeReturned => IsReturn && !_isReturned;

    public bool hasPassenger = false;
    private bool _isReturned = false;

    public Sprite[] carSprites;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = carSprites.Random();
    }

    public void Launch()
    {
        transform.parent = null;
        gameObject.AddComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().AddForce(-transform.right * CarDriveSpeed);
    }

    public void ReturnCar()
    {
        IsReturn = true;
        var rigidBody = GetComponent<Rigidbody2D>();
        var localScale = transform.localScale;
        transform.localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
        ;
        rigidBody.AddForce(transform.right * (CarDriveSpeed * 1.3f));
    }

    public void SetReturnHandled()
    {
        _isReturned = true;
    }

    private void OnCollisionEnter(Collision other) => HandleCollision(other.gameObject);
    private void OnCollisionEnter2D(Collision2D other) => HandleCollision(other.gameObject);
    private void OnTriggerEnter(Collider other) => HandleCollision(other.gameObject);
    private void OnTriggerEnter2D(Collider2D other) => HandleCollision(other.gameObject);

    private void HandleCollision(GameObject other)
    {
        const int carLayer = 8;
        if (other.layer == carLayer)
            OnCrash(other);
    }

    private void OnCrash(GameObject other)
    {
        _audioPlayer.PlayCarCrash();
        Debug.Log("Crashed!");
        GameState.Current.DecreaseStarRating();
        Destroy(other);
        Destroy(gameObject);
    }
}
