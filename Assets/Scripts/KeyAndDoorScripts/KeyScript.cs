using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyScript : MonoBehaviour
{
    public PrefabAssetType key;

    public int currentKeyCount = 0;

    public int maxKeyCount = 4;

    bool hasKey = false;

    bool doorOpened = true;

    public float doorRotationVelocity;


    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        doorOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        UsingKey();
    }

    // When a key is collected by colliding to it, you can press "E" to open a door, which can be closed too (maybe).

    void UsingKey()
    {   

        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        GetComponentInParent<PrefabAssetType>();

        if (hasKey == true && doorOpened == false)
        {
            GetComponentInParent<PrefabAssetType>();
            // Get the rotation velocity of the door so it can be used to open and/or close the door within a specific amount of time.
            // Make the door move 75 degrees on the Y axis.
            // Make the door move -75 degrees on the Y axis IF you want to close the door.
            // Show a string "Open door" "Close door" depending on what you want to do with the door.
            // If the door has been opened disabled the "doorOpened" bool, so you can just close it and open it without a key.
            // When the player uses the key, it can't use it again, meaning that it gets destroyed.
        }
        else if (hasKey == false)
        {
            // Show a string "Door locked" if the player doesn't have a key to open the door.
            // Keep the "doorOpened" bool as false.
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            //Destroy(gameObject.GetComponentInParent.PrerfabAssetType);
            Destroy(gameObject);

        }
        if (currentKeyCount < maxKeyCount)
        {
            currentKeyCount++;
        }
        else if (currentKeyCount >= maxKeyCount)
        {
            return;
        }
    }
}
