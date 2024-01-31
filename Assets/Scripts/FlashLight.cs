using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    // We get the flash light, which is a spot light.
    [SerializeField] Light flashLight;

    public GameObject battery;

    // Variable created to set the maximum amount of batteries we can have.
    [SerializeField] private int maxBatteryCount = 3;

    // Variable created to see how many batteries we currently have.
    [SerializeField] private int currentBatteries = 1;

    // Variable created to see how much intensity does the torchlight currently have.
    [SerializeField] private float maxIntensity = 3;

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
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Off();
        }

        if (Input.GetKeyDown(KeyCode.E)) 
        { 
            GameObject.Destroy(battery);
            AddBattery();
        }

    }

    void On()
    {
        if (currentBatteries > 0)
        {
            float intensityPercet = (float)currentBatteries / (float)maxBatteryCount;
            
            float intensityFactor = maxIntensity * intensityPercet;

            flashLight.intensity = intensityFactor;
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
    }
}
