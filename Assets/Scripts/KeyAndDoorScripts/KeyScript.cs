using UnityEngine;


public class KeyScript : MonoBehaviour
{
    public int currentKeyCount = 0;

    public int maxKeyCount = 4;

    public GameObject keyOB;

    private bool spaceAvailable;


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
            currentKeyCount = 4;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key") && spaceAvailable == true)
        {
            GameObject.Destroy(other.transform.gameObject);
            AddKey();
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
