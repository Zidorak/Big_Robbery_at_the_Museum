using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject batterySprite1;
    public GameObject batterySprite2;
    public GameObject batterySprite3;

    // We get the flash light, which is a spot light.
    public Light flashLight;

    // Variable created to set the maximum amount of batteries we can have.
    public int maxBatteryCount = 3;

    // Variable created to see how many batteries we currently have.
    public int currentBatteries = 0;

    // Variable created to manage the life time of the batteries.
    public float timeSpeed;

    // Condition created to see if the light is on or off.
    public bool lightOn;

    // Condition created to see if the player has space for more batteries or not.
    public bool spaceAvailable;

    // State machine to handle the intensity of the flash light with 4 different states.
    public State intensityState;

    // Play Audio when turning the flashlight on and off.
    public AudioSource on;
    public AudioSource off;

    // States
    public enum State
    {
        Battery0,
        Battery1,
        Battery2,
        Battery3
    }

    // Start is called before the first frame update
    void Start()
    {
        // We set the torchlight to be off at the start of the game.
        flashLight.enabled = false;
        
        // We set the space available to true so the player can start picking batteries up. 
        spaceAvailable = true;

        // We set the state to be Battery0.
        intensityState = State.Battery0;

        batterySprite1.SetActive(false);
        batterySprite2.SetActive(false);
        batterySprite3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // We call the OnOff function on Update().
        if (Input.GetKeyDown(KeyCode.F))
        {
            On();
            lightOn = true; // The boolean created turns to true after the light turns on.
            on.Play();
        }

        if (lightOn == true)
        {
            FlashLightIntensity(); // If the boolean is true, then we run FlashLightIntensity().
        }



        if (Input.GetKeyDown(KeyCode.R))
        {
            Off();
            lightOn = false; // The boolean created turns to false after the light turns off.
            off.Play();
        }

        if (flashLight.intensity > 3f)
        {
            spaceAvailable = false;
            Debug.Log("Battery = 3");
            flashLight.intensity = 3f;
            intensityState = State.Battery3;
        }

        // Setting the sprites to active depending on the amount.

        if (currentBatteries == 0)
        {
            batterySprite1.SetActive(false);
            batterySprite2.SetActive(false);
            batterySprite3.SetActive(false);
        }
        else if (currentBatteries == 1)
        {
            batterySprite1.SetActive(true);
            batterySprite2.SetActive(false);
            batterySprite3.SetActive(false);
        }
        else if (currentBatteries == 2)
        {
            batterySprite1.SetActive(true);
            batterySprite2.SetActive(true);
            batterySprite3.SetActive(false);
        }
        else if (currentBatteries == 3)
        {
            batterySprite1.SetActive(true);
            batterySprite2.SetActive(true);
            batterySprite3.SetActive(true);
        }
    }

    /* OnTriggerEnter uses a collider to compare the tag, which in this case is "Battery",
       then, if it matches the tag during collision, the object (battery) gets destroyed and 
       finally calls the AddBattery function. */
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Battery") && spaceAvailable == true)
        {
            GameObject.Destroy(other.transform.gameObject);
            flashLight.intensity++;
            AddBattery();
        }
    }

    public void On()
    {
        // The light is enabled.
        if (flashLight.intensity > 0)
        {
            flashLight.enabled = true;
        }
    }

    public void Off()
    {
        // The light is disabled. 
        flashLight.enabled = false;

        /* If the intensity is 0, then currentBatteries is 0,
           there is space to pick up batteries,
           the flashlight gets disabled and it turns off if it was on. */
        if (flashLight.intensity == 0)
        {
            currentBatteries = 0;
            spaceAvailable = true;
            Debug.Log("No battery");
            flashLight.enabled = false;
            lightOn = false;
            off.Play();
        }
    }

    public void AddBattery()
    {
        /* If the currentBatteries is less than the 3 and the space is available,  
           keep the available space and increase the currentBatteries by 1. */
        if (currentBatteries < maxBatteryCount && spaceAvailable == true)
        {
            spaceAvailable = true;
            currentBatteries++;
        }

        // If the currentBatteries is 3, there is no more space for batteries.
        if (currentBatteries == maxBatteryCount)
        {
            spaceAvailable = false;
            Debug.Log("Battery = 3 You have no more space");
            return;
        }
    }

    // This function will handle the intensity of the flashlight, which will get lower after some time.
    public void FlashLightIntensity()
    {
        /* We have to make the light decays with time, dropping its intensity when on, so we
           decrease flashlight intensity with Time.deltaTime multiplied by timeSpeed.*/
        flashLight.intensity -= Time.deltaTime * timeSpeed;  

        // Inside FlashLightIntensity() is where we handle the logic of the state machines.
        switch (intensityState)
        {
            // State accessed when currentBatteries is 0.
            case State.Battery0:

                Debug.Log("Battery = 0");

                /* When the intensity of the flashlight is 0, we turn off the flashlight
                   and make space available to true. */
                if (flashLight.intensity == 0f)
                {
                    spaceAvailable = true;
                    flashLight.enabled = false;
                    Off();
                }
                
            break;
        }


        
        switch (intensityState)
        {
            // State accessed when currentBatteries is 1.
            case State.Battery1:

                Debug.Log("Battery = 1");

                /* When the intensity of the flashlight is less or equal to 1.5
                   and more than 0.1, we keep the space available to true. */
                if (flashLight.intensity <= 1.9f && flashLight.intensity > 0.1f)
                {
                    spaceAvailable = true;
                }

                // When the intensity is less or equal to 0.1, we change state to Battery0.
                if (flashLight.intensity <= 0.1f)
                {
                    intensityState = State.Battery0;
                }
                
            break;
        }



        switch (intensityState)
        {
            // State accessed when currentBatteries is 2.
            case State.Battery2:

                Debug.Log("Battery = 2");

                /* When the intensity of the flashlight is less or equal to 2
                   and more than 1.5, we keep the space available to true. */
                if (flashLight.intensity <= 2 && flashLight.intensity > 0.9f)
                {
                    spaceAvailable = true;
                }

                // When the intensity is less or equal to 1.5, we change state to Battery1.
                if (flashLight.intensity <= 0.9f)
                {
                    intensityState = State.Battery1;
                }

            break;
        }



        switch (intensityState)
        {
            // State accessed when currentBatteries is 3.
            case State.Battery3:

                Debug.Log("Battery = 3");

                /* When the intensity of the flashlight is less or equal to 2.9
                   and more than 2, we change the space available to false. */
                if (flashLight.intensity <= 2.9 && flashLight.intensity > 2f)
                {
                    spaceAvailable = false;
                }

                // When the intensity is less or equal to 2, we change state to Battery2.
                if (flashLight.intensity <= 2f)
                {
                    intensityState = State.Battery2;
                }

            break;
        }

        /* If the intensity is more than 2.9, we keep the space available to false 
           and we access the Battery3 state. */
        if (flashLight.intensity > 2.9f)
        {
            spaceAvailable = false;
            intensityState = State.Battery3;
        }

        // The following "if's" statements are made to add and dispose batteries depending on the state.
        if (intensityState == State.Battery0)
        {
            currentBatteries = 0;
        }
        else if (intensityState == State.Battery1)
        {
            currentBatteries = 1;
        }
        else if (intensityState == State.Battery2)
        {
            currentBatteries = 2;
        }
        else if (intensityState == State.Battery3)
        {
            currentBatteries = 3;
        }
        else
        {
            return;
        }
    }
}
