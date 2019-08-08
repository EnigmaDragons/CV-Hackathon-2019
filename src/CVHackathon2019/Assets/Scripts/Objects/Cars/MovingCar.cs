using UnityEngine;
using Assets.Scripts;

public class MovingCar : MonoBehaviour
{
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
        transform.localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z); ;
        rigidBody.AddForce(transform.right * CarDriveSpeed * 2);
    }

    public void SetReturnHandled()
    {
        _isReturned = true;
    }
}
