using UnityEngine;
using Assets.Scripts;

public class Customer : MonoBehaviour
{
    public int MinSpeed = 10;
    public int MaxSpeed = 30;
    public int HundrethsYVariance = 80;
    
    public int CustomerReturnRate = 8;
    private bool _isDone;
    
    void Start()
    {
        var pos = gameObject.transform.position;
        var modifier = Rng.Int(-HundrethsYVariance, HundrethsYVariance) * 0.01f;
        var newY = pos.y + modifier; 
        gameObject.transform.position = new Vector3(pos.x, newY, pos.z);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Rng.Int(MinSpeed, MaxSpeed), 0));
    }

    void Update()
    {
        if (!_isDone && GameState.Current.IsGameOver)
        {
            _isDone = true;
            Destroy(gameObject, 1f);
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

    private bool CustomerReturnsCar()
    {
        var chance = Rng.Int(1, 100);
        return (chance <= CustomerReturnRate);
    }

    private void OnCarCollide(GameObject other)
    {
        if (CustomerReturnsCar())
        {
            var car = other.GetComponent<MovingCar>();
            car.ReturnCar();
            return;
        }

        GameState.Current.OnCustomerServed();
        Destroy(gameObject);
        Destroy(other);
    }
}
