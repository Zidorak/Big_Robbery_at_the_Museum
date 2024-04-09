using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject battery;

    private void Start()
    {
        InvokeRepeating("Spawn1stFloor", 5, 15);
        InvokeRepeating("Spawn2ndFloor", 5, 15);
    }

    // Update is called once per frame
    void Spawn1stFloor()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-35, 35), 1, Random.Range(-35, 35));
        Instantiate(battery, randomSpawnPosition, Quaternion.identity);
    }

    void Spawn2ndFloor()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-35, 35), 8, Random.Range(-35, 35));
        Instantiate(battery, randomSpawnPosition, Quaternion.identity);
    }
}
