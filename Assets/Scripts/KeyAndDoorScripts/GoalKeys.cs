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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedKey"))
        {
            GameObject.Destroy(other.transform.gameObject);
            AddRedKey();
        }
        if (other.CompareTag("BlueKey"))
        {
            GameObject.Destroy(other.transform.gameObject);
            AddBlueKey();
        }
        if (other.CompareTag("GreenKey"))
        {
            GameObject.Destroy(other.transform.gameObject);
            AddGreenKey();
        }
        if (other.CompareTag("YellowKey"))
        {
            GameObject.Destroy(other.transform.gameObject);
            AddYellowKey();
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