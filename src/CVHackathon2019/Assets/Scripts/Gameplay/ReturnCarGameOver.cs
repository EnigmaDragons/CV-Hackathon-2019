﻿using UnityEngine;

public class ReturnCarGameOver : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) => HandleCollision(other.gameObject);
    private void OnCollisionEnter2D(Collision2D other) => HandleCollision(other.gameObject);
    private void OnTriggerEnter(Collider other) => HandleCollision(other.gameObject);
    private void OnTriggerEnter2D(Collider2D other) => HandleCollision(other.gameObject);

    private void HandleCollision(GameObject other)
    {
        if (GameState.Current.IsGameInProgres)
        {
            const int carLayer = 8;
            //Debug.Log($"layer = {other.layer}");
            if (other.layer == carLayer)
            {
                var car = other.GetComponent<MovingCar>();
                if (car.IsReturn)
                    SetGameOver();
            }
        }
    }

    private void SetGameOver()
    {
        GameState.Current.DecreaseStarRating();
    }
}