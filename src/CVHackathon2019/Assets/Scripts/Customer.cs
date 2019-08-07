using UnityEngine;
using Assets.Scripts;

public class Customer : MonoBehaviour
{
    public float[] Speeds = { 10f, 10f, 10f, 10f,  8f, 6f, 4f, 12f, 14f, 16f};
    public int CustomerReturnRate = 8;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Speeds.Random(), 0));
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
        Debug.Log("chance = " + chance);
        return (chance <= CustomerReturnRate);
    }

    private void OnCarCollide(GameObject other)
    {
        if (CustomerReturnsCar())
        {
            var car = other.GetComponent<Rigidbody2D>();
            car.AddForce(transform.right * 2 * 137);
            return;
        }

        GameState.Current.OnCustomerServed();
        Destroy(gameObject);
        Destroy(other);
    }
}
