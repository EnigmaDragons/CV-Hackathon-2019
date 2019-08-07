using System.Collections;
using UnityEngine;
using Assets.Scripts;

public class Spawner : MonoBehaviour
{
    public float SpawnIntervalSeconds = 1.5f;
    public bool IsGameOver = false;
    public GameObject[] Customers;
    public GameObject[] Lanes;
    

    void Start()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while(!IsGameOver)
        {
            yield return new WaitForSeconds(SpawnIntervalSeconds);
            SpawnCustomer();
        }
    }

    private void SpawnCustomer()
    {
        var customerPrototype = Customers[0];
        Instantiate(customerPrototype, Lanes.Random<GameObject>().transform.position, Quaternion.identity);
    }
}
