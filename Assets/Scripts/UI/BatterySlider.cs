using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatterySlider : MonoBehaviour
{
    public Slider slider;
    public Gradient sliderGradient;
    public Image fill;
    public FlashLight flashLightScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBattery()
    {
        slider.value = flashLightScript.currentBatteries;
        fill.color = sliderGradient.Evaluate(slider.value);
    }
}
