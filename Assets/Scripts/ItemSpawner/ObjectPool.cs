using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] objectPool;

    public GameObject battery;

    public int poolCount;

    int lastIndex;

    // Start is called before the first frame update
    void Start()
    {
        objectPool = new GameObject[poolCount];
        
        for (int i = 0; i <= poolCount; i++)
        {
            objectPool[i] = Instantiate(battery) as GameObject;
            objectPool[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPooledObject()
    {
        int passIndex = lastIndex;
        if (lastIndex == poolCount) 
        { 
            lastIndex = 0;
        }

        objectPool[passIndex].SetActive(true);
        return objectPool[passIndex];
    }
}
