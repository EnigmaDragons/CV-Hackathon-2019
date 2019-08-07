using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) => DestroyObject(other.gameObject);
    private void OnCollisionEnter2D(Collision2D other) => DestroyObject(other.gameObject);
    private void OnTriggerEnter(Collider other) => DestroyObject(other.gameObject);
    private void OnTriggerEnter2D(Collider2D other) => DestroyObject(other.gameObject);

    private void DestroyObject(GameObject gobj)
    {
    	Destroy(gobj);
        // Debug.Log("Game Over");
        // GameState.Current.Outcome = LevelOutcome.GameOver;
    }
}
