﻿using UnityEngine;
using Assets.Scripts;

public class Customer : MonoBehaviour
{
    public int MinSpeed = 10;
    public int MaxSpeed = 30;
    public int HundrethsYVariance = 80;
    
    void Start()
    {
        var pos = gameObject.transform.position;
        var modifier = Rng.Int(-HundrethsYVariance, HundrethsYVariance) * 0.01f;
        var newY = pos.y + modifier; 
        gameObject.transform.position = new Vector3(pos.x, newY, pos.z);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Rng.Int(MinSpeed, MaxSpeed), 0));
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

    private void OnCarCollide(GameObject other)
    {
        GameState.Current.OnCustomerServed();
        Destroy(gameObject);
        Destroy(other);
    }
}
