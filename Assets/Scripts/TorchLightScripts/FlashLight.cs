using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    // We get the flash light, which is a spot light.
    [SerializeField] Light flashLight;

    // Variable created to set the maximum amount of batteries we can have.
    [SerializeField] private int maxBatteryCount = 3;

    // Variable created to see how many batteries we currently have.
    [SerializeField] private int currentBatteries;

    // Variable created to see what's the current intensity of the torchlight.
    [SerializeField] private int currentIntensity;

    // Variable created to see how much intensity does the torchlight currently have.
    [SerializeField] private float maxIntensity = 3;

    // Variable created to manage the life time of the batteries.
    public float timeSpeed;

    // Condition created to see if the light is on or off.
    private bool lightOn;


    // Start is called before the first frame update
    void Start()
    {
        // We set the torchlight to be off at the start of the game.
        flashLight.enabled = false;
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
        
        // Check to dispose of used batteries.
       // if (currentIntensity > 3 && currentIntensity < 4)
        //{
          //  currentIntensity = 3;
            //currentBatteries = 3;
            //currentBatteries--;
            //currentIntensity--;
        //}
        if (currentIntensity > 1 && currentIntensity < 3)
        {

            flashLight.intensity = 2;
            currentBatteries = 2;
            currentBatteries--;
            currentIntensity--;
        }
        else if (currentIntensity > 1 && currentIntensity < 2)
        {
            flashLight.intensity = 1;
            currentBatteries = 1;
            currentBatteries--;
            currentIntensity--;
        }
    }

    /* OnTriggerEnter uses a collider to compare the tag, which in this case is "Battery",
       then, if it matches the tag during collision, the object (battery) gets destroyed and 
       finally calls the AddBattery function. */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Battery"))
        {
            GameObject.Destroy(other.transform.gameObject);
            AddBattery();
        }
    }

    void On()
    {
        // The light is enabled.
        if (currentBatteries > 0)
        {
            flashLight.enabled = true;
        }
    }

    void Off()
    {
        // The light is disabled. 
        flashLight.enabled = false;
    }

    void AddBattery()
    {
        // We use this method to add batteries.
        if (currentBatteries >= maxBatteryCount)
        {
            return;
        }
        currentBatteries++;
        
        /* If the currentIntensity is less or equal to the maxIntensity, then the currentIntensity 
           will match the currentBatteries. Finally the intensity component of the flasLight will 
           be equal to the currentIntensity */
        if (currentIntensity <= maxIntensity)
        {
            currentIntensity = currentBatteries;
            flashLight.intensity = currentIntensity;
        }
    }

    // This function will handle the intensity of the flashlight, which will get lower after some time.
    void FlashLightIntensity()
    {
        // We have to make the light decays after a fixed time, dropping its intensity when on.
        if (flashLight.intensity > 0)
        {
            // Get time and try to drop the intensity while the light is on.
            flashLight.intensity -= Time.deltaTime * currentIntensity * timeSpeed;
        }
    }
}
