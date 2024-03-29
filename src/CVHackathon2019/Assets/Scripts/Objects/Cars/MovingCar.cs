﻿using UnityEngine;
using Assets.Scripts;

public class MovingCar : MonoBehaviour
{
    public AudioPlayer _audioPlayer;
    public bool IsReturn = false;
    public float CarDriveSpeed = 137;
    public bool NeedsToBeReturned => IsReturn && !_isReturned;
    public float SafeReturnX = 10f;
    public GameObject Explosion;

    public bool hasPassenger = false;
    private bool _isReturned = false;

    public Sprite[] carSprites;

    public MoneyScoreCalculators MoneyScoreCalculators = new MoneyScoreCalculators();

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = carSprites.Random();
    }

    void Update()
    {
        if (IsReturn && !_isReturned && transform.position.x > SafeReturnX)
        {
            DestroyImmediate(GetComponent<Rigidbody2D>());
            Destroy(gameObject);
        }
    }

    public void Launch()
    {
        transform.parent = null;
        gameObject.AddComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().AddForce(-transform.right * CarDriveSpeed);
    }

    public void ReturnCar()
    {
        if (IsReturn)
            return;
        
        IsReturn = true;
        
        var rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody == null)
            return;
        
        var localScale = transform.localScale;
        transform.localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
        rigidBody.AddForce(transform.right * (CarDriveSpeed * 2.0f));
    }

    public void SetReturnHandled()
    {
        _isReturned = true;
    }

    private void OnCollisionEnter(Collision other) => HandleCollision(other.gameObject);
    private void OnCollisionEnter2D(Collision2D other) => HandleCollision(other.gameObject);
    private void OnTriggerEnter(Collider other) => HandleCollision(other.gameObject);
    private void OnTriggerEnter2D(Collider2D other) => HandleCollision(other.gameObject);
    private void HandleCollision(GameObject other)
    {
        const int carLayer = 8;
        if (other.layer == carLayer)
            OnCrash(other);
    }

    private void OnCrash(GameObject other)
    {
        _audioPlayer.PlayCarCrash();
        Instantiate(Explosion, transform);
        Debug.Log("Crashed!");

        MoneyScoreCalculators.MinusMoneyCarsCrash();
        
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(other.GetComponent<Rigidbody2D>());
        Destroy(other.GetComponent<BoxCollider2D>());
        Destroy(GetComponent<SpriteRenderer>(), 0.4f);
        Destroy(other.GetComponent<SpriteRenderer>(), 0.4f);
        Destroy(other, 2f);
        Destroy(gameObject, 2f);
    }
}
