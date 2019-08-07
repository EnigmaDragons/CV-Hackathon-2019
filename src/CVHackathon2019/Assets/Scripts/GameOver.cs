using Assets.Scripts;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) => SetGameOver();
    private void OnCollisionEnter2D(Collision2D other) => SetGameOver();
    private void OnTriggerEnter(Collider other) => SetGameOver();
    private void OnTriggerEnter2D(Collider2D other) => SetGameOver();

    private void SetGameOver()
    {
        Debug.Log("Game Over");
        GameState.Current.IsGameOver = true;
    }
}
