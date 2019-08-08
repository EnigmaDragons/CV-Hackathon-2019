using UnityEngine;

public class AcceptReturns : MonoBehaviour
{
    public HaulerPlayerScript Hauler;
    
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
        if (car.IsReturn)
        {
            Destroy(other);
        }

        if (car.IsReturn && !Hauler.HasCar)
        {
            Hauler.Return(car);
        }
    }
}
