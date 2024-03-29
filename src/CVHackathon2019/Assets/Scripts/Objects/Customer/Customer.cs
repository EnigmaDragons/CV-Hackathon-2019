﻿using UnityEngine;
using Assets.Scripts;

public class Customer : MonoBehaviour
{
    public int HundrethsYVariance = 80;
    public AudioPlayer _audioPlayer;
    private bool _isDone;
    private Rigidbody2D _body;
    
    void Start()
    {
        var pos = gameObject.transform.position;
        var modifier = Rng.Int(-HundrethsYVariance, HundrethsYVariance) * 0.01f;
        var newY = pos.y + modifier; 
        gameObject.transform.position = new Vector3(pos.x, newY, pos.z);
        _body = GetComponent<Rigidbody2D>();
        _body.AddForce(new Vector2(GameState.Current.CustomerSpeed, 0));
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

    private bool CustomerReturnsCar() => Rng.Int(1, 100) <= GameState.Current.CarReturnRate;

    private void AttachCustomerToCar(MovingCar car)
    {
        gameObject.transform.SetParent(car.transform);
        gameObject.GetComponent<Animator>().SetBool("IsCatching", true);
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        car.hasPassenger = true;
        car.transform.position = car.transform.position + new Vector3(0,0,1);
    }

    private void OnCarCollide(GameObject other)
    {
        var car = other.GetComponent<MovingCar>();

        if (car.hasPassenger) return;
        if (car.IsReturn) return;

        if (CustomerReturnsCar())
        {
            car.ReturnCar();
            var scale = transform.localScale;
            transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
            _body.AddForce(-transform.right * GameState.Current.CustomerSpeed * 2);
            return;
        }
        _audioPlayer.PlayCustomerServed();
        GameState.Current.OnCustomerServed();

        AttachCustomerToCar(car);
    }

    public void Despawn()
    {
        _audioPlayer.PlayAngryCustomer();
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        Destroy(gameObject.GetComponent<Collider2D>());
        Destroy(gameObject, 3f);
    }
}
