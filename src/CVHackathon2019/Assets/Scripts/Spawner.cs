using System.Collections;
using System.Linq;
using UnityEngine;
using Assets.Scripts;

public class Spawner : MonoBehaviour
{
    public float SpawnIntervalSeconds = 1.5f;
    public bool IsGameOver => GameState.Current.IsGameOver;
    public GameObject[] Customers;
    public GameObject Lanes;
    
    private Transform[] LanePositions => Lanes.transform.OfType<Transform>().Select(x => x).ToArray();

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
        Instantiate(customerPrototype, LanePositions.Random().position, Quaternion.identity);
    }
}
