using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderScript : MonoBehaviour
{
    public float number;
    public Slider slider;
    public string meterName;

    // Start is called before the first frame update
   
    public void setSliderValue(float sliderValue)
    {
        number = sliderValue;
        slider.value = number;
    }

    public void setMaxValue(float value)
    {
        slider.maxValue = value;
    }

}
