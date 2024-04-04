using System.Collections;
using UnityEngine;

public class GoalDoor : MonoBehaviour
{
    public Animator doorAnimator;


    public GameObject RedLockOB;
    public GameObject BlueLockOB;
    public GameObject YellowLockOB;
    public GameObject GreenLockOB;


    public GameObject RedKeyOB;
    public GameObject BlueKeyOB;
    public GameObject YellowKeyOB;
    public GameObject GreenKeyOB;


    public GameObject openText;
    public GameObject closeText;
    public GameObject lockedText;


    public AudioSource openSound;
    public AudioSource closeSound;
    public AudioSource lockedSound;
    public AudioSource unlockedSound;


    public bool inReach;
    public bool doorisOpen;
    public bool doorisClosed;
    public bool locked;
    public bool unlocked;


    public GoalKeys goalKeys;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && doorisClosed)
        {
            inReach = true;
            openText.SetActive(true);
        }

        if (other.gameObject.tag == "Reach" && doorisOpen)
        {
            inReach = true;
            closeText.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            lockedText.SetActive(false);
            closeText.SetActive(false);
        }
    }

    void Start()
    {
        inReach = false;
        doorisClosed = true;
        doorisOpen = false;
        RedKeyOB.SetActive(false);
        BlueKeyOB.SetActive(false);
        YellowKeyOB.SetActive(false);
        GreenKeyOB.SetActive(false);
        closeText.SetActive(false);
        openText.SetActive(false);
        GetComponent<GoalKeys>();
    }

    void Update()
    {
        if (inReach && RedKeyOB.activeInHierarchy && Input.GetButtonDown("Interact"))
        {
            //unlockedSound.Play();
            locked = true;
            RedKeyOB.SetActive(false);
            RedLockOB.SetActive(false);
        }

        if (inReach && BlueKeyOB.activeInHierarchy && Input.GetButtonDown("Interact"))
        {
            //unlockedSound.Play();
            locked = true;
            BlueKeyOB.SetActive(false);
            BlueLockOB.SetActive(false);
        }

        if (inReach && YellowKeyOB.activeInHierarchy && Input.GetButtonDown("Interact"))
        {
            //unlockedSound.Play();
            locked = true;
            YellowKeyOB.SetActive(false);
            YellowLockOB.SetActive(false);
        }

        if (inReach && GreenKeyOB.activeInHierarchy && Input.GetButtonDown("Interact"))
        {
            //unlockedSound.Play();
            locked = true;
            GreenKeyOB.SetActive(false);
            GreenLockOB.SetActive(false);
        }

        if (inReach && RedLockOB.activeInHierarchy == false && BlueLockOB.activeInHierarchy == false &&
            YellowLockOB.activeInHierarchy == false && GreenLockOB.activeInHierarchy == false &&
            doorisClosed && locked && Input.GetButtonDown("Interact"))
        {
            //unlockedSound.Play();
            locked = false;
            StartCoroutine(unlockDoor());
        }

        if (inReach && doorisClosed && unlocked && Input.GetButtonDown("Interact"))
        {
            doorAnimator.SetBool("Open", true);
            doorAnimator.SetBool("Close", false);
            openText.SetActive(false);
            //openSound.Play();
            doorisOpen = true;
            doorisClosed = false;
            RedLockOB.SetActive(false);
            BlueLockOB.SetActive(false);
            YellowLockOB.SetActive(false);
            GreenLockOB.SetActive(false);
        }

        else if (inReach && doorisOpen && unlocked && Input.GetButtonDown("Interact"))
        {
            doorAnimator.SetBool("Open", false);
            doorAnimator.SetBool("Close", true);
            closeText.SetActive(false);
            //closeSound.Play();
            doorisClosed = true;
            doorisOpen = false;
            RedLockOB.SetActive(true);
            BlueLockOB.SetActive(true);
            YellowLockOB.SetActive(true);
            GreenLockOB.SetActive(true);
        }

        if (inReach && locked && Input.GetButtonDown("Interact"))
        {
            openText.SetActive(false);
            lockedText.SetActive(true);
            //lockedSound.Play();
        }

    }

    IEnumerator unlockDoor()
    {
        yield return new WaitForSeconds(.05f);
        {
            unlocked = true;
            RedLockOB.SetActive(false);
            BlueLockOB.SetActive(false);
            YellowLockOB.SetActive(false);
            GreenLockOB.SetActive(false);
        }
    }
}