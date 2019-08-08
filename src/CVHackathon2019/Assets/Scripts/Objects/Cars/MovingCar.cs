using UnityEngine;

public class MovingCar : MonoBehaviour
{
    public bool IsReturn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnCar()
    {
        IsReturn = true;
        var rigidBody = GetComponent<Rigidbody2D>();
        var localScale = transform.localScale;
        transform.localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z); ;
        rigidBody.AddForce(transform.right * 2 * 137);
    }
}
