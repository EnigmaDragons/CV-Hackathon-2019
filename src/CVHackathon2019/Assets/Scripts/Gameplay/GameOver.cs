using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) => SetGameOver(other.gameObject.GetComponent<Customer>());
    private void OnCollisionEnter2D(Collision2D other) => SetGameOver(other.gameObject.GetComponent<Customer>());
    private void OnTriggerEnter(Collider other) => SetGameOver(other.gameObject.GetComponent<Customer>());
    private void OnTriggerEnter2D(Collider2D other) => SetGameOver(other.GetComponent<Customer>());
    
    private void SetGameOver(Customer customer)
    {
        if (customer != null)
        {
            customer.Despawn();
            GameState.Current.DecreaseStarRating();
        }
    }
}
