using Unity.VisualScripting;
using UnityEngine;


public class KeyScript : MonoBehaviour
{
    public int currentKeyCount = 0;

    public int maxKeyCount = 1;

    public GameObject keyOB;

    private bool spaceAvailable;

    public PlayerInventory inventory;

    public GameObject key;


    // Start is called before the first frame update
    void Start()
    {
        spaceAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentKeyCount == maxKeyCount)
        {
            spaceAvailable = false;
        }
        if (currentKeyCount < maxKeyCount)
        {
            spaceAvailable = true;
        }
        if (currentKeyCount > maxKeyCount)
        {
            spaceAvailable = false;
            currentKeyCount = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key") && spaceAvailable == true)
        {
            GameObject.Destroy(other.transform.gameObject);
            AddKey();

            for (int i = 0; i < inventory.slots.Length; i++) 
            {
                if (inventory.isfull[i] == false)
                {
                    inventory.isfull[i] = true;
                    Instantiate(key, inventory.slots[0].transform, false);
                    break;
                }
            }
        }
    }

    public void AddKey()
    {
        if (currentKeyCount < maxKeyCount)
        {
            currentKeyCount++;
            keyOB.SetActive(true);
            spaceAvailable = true;
        }
    }
}
