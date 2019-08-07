using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float SpawnIntervalSeconds = 1.5f;
    public bool IsGameOver = false;
    public GameObject[] Customers;
    
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
        Instantiate(customerPrototype, new Vector3(100, 400, 0), Quaternion.identity);
    }
}
