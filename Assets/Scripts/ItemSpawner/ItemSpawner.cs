using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject battery;

    public void Start()
    {
        InvokeRepeating("Spawn1stFloor", 5, 15);
        InvokeRepeating("Spawn2ndFloor", 5, 15);
    }

    void Spawn1stFloor()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-35, 35), 1, Random.Range(-35, 35));
        Instantiate(battery, randomSpawnPosition, Quaternion.identity);
    }

    public void Spawn2ndFloor()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-35, 35), 8, Random.Range(-35, 35));
        Instantiate(battery, randomSpawnPosition, Quaternion.identity);
    }
}
