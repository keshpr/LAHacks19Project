﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meterScript : MonoBehaviour
{
    private int number;
    public Text thistext;
    public string meter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        thistext.text = meter + ":  " + number;

    }

    public void setNumber(int numberToSet)
    {
        number = numberToSet;
    }
}
