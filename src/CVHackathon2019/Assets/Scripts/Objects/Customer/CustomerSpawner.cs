using System.Collections;
using System.Linq;
using UnityEngine;
using Assets.Scripts;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject[] Customers;
    public GameObject Lanes;
    public int SpawnVariance = 4;

    public float SpawnIntervalSeconds => GameState.Current.CustomerSpawnInterval;

    private Transform[] LanePositions => Lanes.transform.OfType<Transform>().Select(x => x).ToArray();

    void Start()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (GameState.Current.IsGameInProgres)
        {
            var untilNext = SpawnIntervalSeconds + (Rng.Int(-SpawnVariance, SpawnVariance) * 0.1f);
            yield return new WaitForSeconds(untilNext);
            SpawnCustomer();
        }
    }

    private void SpawnCustomer()
    {
        var customerPrototype = Customers.Random();
        var lane = LanePositions.Random().position;
        Instantiate(customerPrototype, new Vector3(lane.x, lane.y, lane.z), Quaternion.identity);
    }
}