﻿using UnityEngine;

public class AcceptReturns : MonoBehaviour
{
    public HaulerPlayerScript Hauler;
    
    private void OnCollisionEnter(Collision other) => HandleCollision(other.gameObject);
    private void OnCollisionEnter2D(Collision2D other) => HandleCollision(other.gameObject);
    private void OnTriggerEnter(Collider other) => HandleCollision(other.gameObject);
    private void OnTriggerEnter2D(Collider2D other) => HandleCollision(other.gameObject);

    public void Start()
    {
        if (Hauler == null)
            Debug.LogError("Accept Car is missing Hauler");
    }
    
    private void HandleCollision(GameObject other)
    {
        const int carLayer = 8;
        if (other.layer == carLayer)
            OnCarCollide(other);
    }

    private void OnCarCollide(GameObject other)
    {
        var car = other.GetComponent<MovingCar>();
        if (car == null)
            return;
        
        if (car.NeedsToBeReturned && Hauler.HasCar)
        {
            Destroy(car);
        }
        else if (car.NeedsToBeReturned && !Hauler.HasCar)
        {
            Hauler.Return(car);
        }
    }
}
