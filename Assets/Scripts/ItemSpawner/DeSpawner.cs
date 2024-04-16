using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawner : MonoBehaviour
{
    private float deSpawnTimer = 60f;

    private IEnumerator Start()
    {
        float passedTime = 0f;
        while (passedTime < deSpawnTimer)
        {
            passedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
