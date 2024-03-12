using UnityEngine;

public class FlashLight : MonoBehaviour
{
    // We get the flash light, which is a spot light.
    [SerializeField] Light flashLight;

    // Variable created to set the maximum amount of batteries we can have.
    [SerializeField] private int maxBatteryCount = 3;

    // Variable created to see how many batteries we currently have.
    [SerializeField] private int currentBatteries = 0;

    // Variable created to see what's the current intensity of the torchlight.
   // private int currentIntensity = 0;

    // Variable created to see how much intensity does the torchlight currently have.
    // [SerializeField] private float maxIntensity = 3;

    // Variable created to manage the life time of the batteries.
    public float timeSpeed;

    // Condition created to see if the light is on or off.
    private bool lightOn;

    private bool spaceAvailable;

    private State intensityState;

    private enum State
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
        spaceAvailable = true;
       // currentBatteries = currentIntensity;
        intensityState = State.Battery0;
    }

    // Update is called once per frame
    void Update()
    {
        // We call the OnOff function on Update().
        if (Input.GetKeyDown(KeyCode.F))
        {
            On();
            lightOn = true; // The boolean created turns to true after the light turns on.
        }

        if (lightOn == true)
        {
            FlashLightIntensity(); // If the boolean is true, then we run FlashLightIntensity().
        }



        if (Input.GetKeyDown(KeyCode.R))
        {
            Off();
            lightOn = false; // The boolean created turns to false after the light turns off.
        }

        if (flashLight.intensity > 3f)
        {
            spaceAvailable = false;
            Debug.Log("Battery = 3");
            flashLight.intensity = 3f;
            intensityState = State.Battery3;
        }
    }

    /* OnTriggerEnter uses a collider to compare the tag, which in this case is "Battery",
       then, if it matches the tag during collision, the object (battery) gets destroyed and 
       finally calls the AddBattery function. */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Battery") && spaceAvailable == true)
        {
            GameObject.Destroy(other.transform.gameObject);
            flashLight.intensity++;
            AddBattery();
        }
    }

    void On()
    {
        // The light is enabled.
        if (flashLight.intensity > 0)
        {
            flashLight.enabled = true;
        }
    }

    void Off()
    {
        // The light is disabled. 
        flashLight.enabled = false;

        if (flashLight.intensity == 0)
        {
            currentBatteries = 0;
            spaceAvailable = true;
            Debug.Log("No battery");
            flashLight.enabled = false;
            lightOn = false;
        }
    }

    void AddBattery()
    {
        /*  */
        if (currentBatteries < maxBatteryCount && spaceAvailable == true)
        {
            spaceAvailable = true;
            currentBatteries++;
        }

        if (currentBatteries == maxBatteryCount)
        {
            spaceAvailable = false;
            Debug.Log("Battery = 3 You have no more space");
            return;
        }
    }

    // This function will handle the intensity of the flashlight, which will get lower after some time.
    void FlashLightIntensity()
    {
        // We have to make the light decays after a fixed time, dropping its intensity when on.

        flashLight.intensity -= Time.deltaTime * timeSpeed; // COMEBACK TO THIS!!!

        switch (intensityState)
        {
            case State.Battery0:

                Debug.Log("Battery = 0");

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
            case State.Battery1:

                Debug.Log("Battery = 1");

                if (flashLight.intensity <= 1.5f && flashLight.intensity > 0.1f)
                {
                    spaceAvailable = true;
                    //flashLight.intensity -= Time.deltaTime * currentIntensity * timeSpeed;
                }

                if (flashLight.intensity <= 0.1f)
                {
                    //flashLight.intensity -= Time.deltaTime * currentIntensity * timeSpeed;


                    intensityState = State.Battery0;
                }
                //currentBatteries = currentBatteries - 1;
                break;
        }



        switch (intensityState)
        {
            case State.Battery2:

                Debug.Log("Battery = 2");

                if (flashLight.intensity <= 2 && flashLight.intensity > 1.5f)
                {
                    spaceAvailable = true;
                    //flashLight.intensity -= Time.deltaTime * currentIntensity * timeSpeed;
                }

                if (flashLight.intensity <= 1.5f)
                {
                    //flashLight.intensity -= Time.deltaTime * currentIntensity * timeSpeed;


                    intensityState = State.Battery1;
                }
                //currentBatteries = currentBatteries - 1;
                break;
        }



        switch (intensityState)
        {
            case State.Battery3:

                if (flashLight.intensity <= 2.9 && flashLight.intensity > 2f)
                {
                    spaceAvailable = false;
                    //flashLight.intensity -= Time.deltaTime * currentIntensity * timeSpeed;
                }

                if (flashLight.intensity <= 2f)
                {
                    //flashLight.intensity -= Time.deltaTime * currentIntensity * timeSpeed;


                    intensityState = State.Battery2;
                }

                break;
        }

        if (flashLight.intensity > 2.9f)
        {
            spaceAvailable = false;
            //flashLight.intensity -= Time.deltaTime * currentIntensity * timeSpeed;
            Debug.Log("Battery = 3");
            intensityState = State.Battery3;
        }


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
    /* I've tried creating a new boolean called emptyBaterry
       to check if the player has an empty battery and then dispose it.
       I've also plugged the if statements inside the big IF with Time.deltaTime. 
       Just to see if it was possible to fix the issue, which didn't work.
       Now the batteries don't go down, the intensity goes up
       and the intensity on the script goes down, but keeps going below 0. */
}
