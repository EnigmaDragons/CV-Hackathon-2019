using UnityEngine;

public class CarSpawner : MonoBehaviour
{
	public MovingCar Car;
    public Vector3 PositionOffset;

    public MovingCar LoadCar(HaulerPlayerScript haulerPlayerScript)
    {
        var pos = haulerPlayerScript.transform.position + PositionOffset;
        var car = Instantiate(Car, pos, Quaternion.identity, haulerPlayerScript.transform);
        Destroy(car.GetComponent<Rigidbody2D>());
        return car;
    }
}
