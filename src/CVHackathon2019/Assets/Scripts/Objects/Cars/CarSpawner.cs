using UnityEngine;


public class CarSpawner : MonoBehaviour
{
	public MovingCar Car;


    public MovingCar LoadCar(HaulerPlayerScript haulerPlayerScript)
    {
        var car = Instantiate(Car, haulerPlayerScript.transform);
        Destroy(car.GetComponent<Rigidbody2D>());
        return car;
    }
}
