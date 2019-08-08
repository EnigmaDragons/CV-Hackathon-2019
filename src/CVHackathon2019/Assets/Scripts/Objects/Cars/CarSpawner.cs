using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class CarSpawner : MonoBehaviour
{

	public GameObject Cars;
    public int carSpeedForceMultiplier = 137;


	public void LaunchCar()
    {
        var carPrototype = Cars;
        GameObject car = Instantiate(carPrototype, transform.position, Quaternion.identity) as GameObject;
        car.GetComponent<Rigidbody2D>().AddForce(-transform.right * carSpeedForceMultiplier);
    }

    // spawn car from sky
    // load car onto hauler
    // launch car from hauler

}