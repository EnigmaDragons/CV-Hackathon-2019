using UnityEngine;


public class CarSpawner : MonoBehaviour
{
	public GameObject Car;

    public GameObject LoadCar(HaulerPlayerScript haulerPlayerScript)
    {
        var car = Instantiate(Car, haulerPlayerScript.transform);
        Destroy(car.GetComponent<Rigidbody2D>());
        return car;
    }
}
