using UnityEngine;


public class GoalKeys : MonoBehaviour
{
    public int RedKey;

    public int BlueKey;

    public int YellowKey;

    public int GreenKey;

    public GameObject RedKeyOB;
    public GameObject BlueKeyOB;
    public GameObject YellowKeyOB;
    public GameObject GreenKeyOB;

    public PlayerInventory inventory;

    public GameObject RedKeyslot;
    public GameObject BlueKeyslot;
    public GameObject YellowKeyslot;
    public GameObject GreenKeyslot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedKey"))
        {
            GameObject.Destroy(other.transform.gameObject);
            AddRedKey();
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isfull[i] == false)
                {
                    inventory.isfull[i] = true;
                    Instantiate(RedKeyslot, inventory.slots[1].transform, false);
                    break;
                }
            }
        }
        if (other.CompareTag("BlueKey"))
        {
            GameObject.Destroy(other.transform.gameObject);
            AddBlueKey();
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isfull[i] == false)
                {
                    inventory.isfull[i] = true;
                    Instantiate(BlueKeyslot, inventory.slots[2].transform, false);
                    break;
                }
            }
        }
        if (other.CompareTag("YellowKey"))
        {
            GameObject.Destroy(other.transform.gameObject);
            AddYellowKey();
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isfull[i] == false)
                {
                    inventory.isfull[i] = true;
                    Instantiate(YellowKeyslot, inventory.slots[3].transform, false);
                    break;
                }
            }
        }
        if (other.CompareTag("GreenKey"))
        {
            GameObject.Destroy(other.transform.gameObject);
            AddGreenKey();
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isfull[i] == false)
                {
                    inventory.isfull[i] = true;
                    Instantiate(GreenKeyslot, inventory.slots[4].transform, false);
                    break;
                }
            }
        }
        
    }

    public void AddRedKey()
    {
        RedKey++;
        RedKeyOB.SetActive(true);
    }
    public void AddBlueKey()
    {
        BlueKey++;
        BlueKeyOB.SetActive(true);
    }

    public void AddGreenKey()
    {
        GreenKey++;
        GreenKeyOB.SetActive(true);
    }
    public void AddYellowKey()
    {
        YellowKey++;
        YellowKeyOB.SetActive(true);
    }
}