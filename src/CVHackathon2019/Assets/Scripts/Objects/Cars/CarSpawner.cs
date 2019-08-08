using UnityEngine;

public class CarSpawner : MonoBehaviour
{
	public MovingCar Car;
    public Vector3 PositionOffset;

    public MovingCar LoadCar(HaulerPlayerScript haulerPlayerScript)
    {
        var car = Instantiate(Car, haulerPlayerScript.transform.position + PositionOffset, Quaternion.identity, haulerPlayerScript.transform);
        Destroy(car.GetComponent<Rigidbody2D>());
        return car;
    }
}
