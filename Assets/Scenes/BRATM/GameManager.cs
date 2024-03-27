using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject spawnerPoint1;
    public Transform spawnerTransform1;

    public GameObject spawnerPoint2;
    public Transform spawnerTransform2;

    public GameObject spawnerPoint3;
    public Transform spawnerTransform3;

    public GameObject spawnerPoint4;
    public Transform spawnerTransform4;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("Spawn", 5, 30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        if (Application.isPlaying && spawnerPoint1 != null) 
        {
            //InvokeRepeating("Spawn", 30, 1);
            Instantiate(spawnerPoint1, spawnerTransform1.position, spawnerTransform1.rotation);
        }
        if (Application.isPlaying && spawnerPoint2 != null)
        {
            //InvokeRepeating("Spawn", 30, 1);
            Instantiate(spawnerPoint2, spawnerTransform2.position, spawnerTransform2.rotation);
        }
        if (Application.isPlaying && spawnerPoint3 != null)
        {
            //InvokeRepeating("Spawn", 30, 1);
            Instantiate(spawnerPoint3, spawnerTransform3.position, spawnerTransform3.rotation);
        }
        if (Application.isPlaying && spawnerPoint4 != null)
        {
            //InvokeRepeating("Spawn", 30, 1);
            Instantiate(spawnerPoint4, spawnerTransform4.position, spawnerTransform4.rotation);
        }
    }
}
