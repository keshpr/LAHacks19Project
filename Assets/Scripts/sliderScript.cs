using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderScript : MonoBehaviour
{
    public int number;
    public Slider slider;
    public string meterName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = number;
        // update with meterScript simulatenously...
    }

    void setSliderValue(int sliderValue)
    {
        number = sliderValue;
    }

}
