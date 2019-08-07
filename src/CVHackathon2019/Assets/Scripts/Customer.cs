using UnityEngine;

public class Customer : MonoBehaviour
{
    public float Speed = 10f;
    
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Speed, 0));
    }
}
