using System.Collections;
using UnityEngine;

public class Doors : MonoBehaviour
{

    public Animator doorAnimator;
    public GameObject lockOB;
    public GameObject keyOB;
    public GameObject openText;
    public GameObject closeText;
    public GameObject lockedText;


    public AudioSource openSound;
    public AudioSource closeSound;
    public AudioSource lockedSound;
    public AudioSource unlockedSound;

    private bool inReach;
    private bool doorisOpen;
    private bool doorisClosed;
    public bool locked;
    public bool unlocked;

    public KeyScript script;  




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && doorisClosed)
        {
            inReach = true;
            //openText.SetActive(true);
        }

        if (other.gameObject.tag == "Reach" && doorisOpen)
        {
            inReach = true;
            //closeText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            //openText.SetActive(false);
            //lockedText.SetActive(false);
            //closeText.SetActive(false);
        }
    }

    void Start()
    {
        inReach = false;
        doorisClosed = true;
        doorisOpen = false;
        keyOB.SetActive(false);
        //closeText.SetActive(false);
        //openText.SetActive(false);
        GetComponent<KeyScript>();
    }




    void Update()
    {
        if (lockOB.activeInHierarchy)
        {
            locked = true;
            unlocked = false;
        }

        else
        {
            unlocked = true;
            locked = false;
        }

        if (inReach && keyOB.activeInHierarchy && Input.GetButtonDown("Interact"))
        {
            //unlockedSound.Play();
            locked = false;
            keyOB.SetActive(true);
            StartCoroutine(unlockDoor());
        }

        if (script.currentKeyCount == 0)
        {
            keyOB.SetActive(false);
        }

        if (inReach && doorisClosed && unlocked && Input.GetButtonDown("Interact"))
        {
            doorAnimator.SetBool("Open", true);
            doorAnimator.SetBool("Close", false);
            //openText.SetActive(false);
            //openSound.Play();
            doorisOpen = true;
            doorisClosed = false;
        }

        else if (inReach && doorisOpen && unlocked && Input.GetButtonDown("Interact"))
        {
            doorAnimator.SetBool("Open", false);
            doorAnimator.SetBool("Close", true);
            //closeText.SetActive(false);
            //closeSound.Play();
            doorisClosed = true;
            doorisOpen = false;
            lockOB.SetActive(true);
            StartCoroutine(lockDoor());
        }

        if (inReach && locked && Input.GetButtonDown("Interact"))
        {
            //openText.SetActive(false);
            //lockedText.SetActive(true);
            //lockedSound.Play();
        }

    }

    IEnumerator unlockDoor()
    {
        yield return new WaitForSeconds(.05f);
        {
            unlocked = true;
            lockOB.SetActive(false);
            if (doorisOpen == true)
            {
                script.currentKeyCount = script.currentKeyCount - 1;
            }
        }
    }

    IEnumerator lockDoor()
    {
        yield return new WaitForSeconds(.05f);
        {
            unlocked = false;
            lockOB.SetActive(true);
            if (doorisOpen == false)
            {
                script.currentKeyCount = script.currentKeyCount + 1;
                keyOB.SetActive(true);
            }
        }
    }
}