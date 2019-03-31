using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{

    public GameObject[] resources;
    public float[] initResourceAmts;
    private float[] resourceAmounts;
    GameObject activeResource;
    int numResources;
    //float times;

    public sliderScript foodSlider;
    public sliderScript populationSlider;
    public sliderScript waterSlider;

    public meterScript foodText;
    public meterScript populationText;
    public meterScript waterText;

    public GameObject winLevel;
    public GameObject loseLevel;

    CursorScript cursor;
    // Start is called before the first frame update
    void Start()
    {
        winLevel.SetActive(false);
        loseLevel.SetActive(false);
        cursor = this.gameObject.GetComponent<CursorScript>();
        activeResource = null;
        numResources = resources.Length;
        resourceAmounts = new float[numResources];
        
        for (int i = 0; i < numResources; i++)
        {
            resourceAmounts[i] = initResourceAmts[i];
            if(resources[i].tag == "House")
            {
                populationSlider.setMaxValue(2 * initResourceAmts[i] + 10);
                populationText.setNumber(initResourceAmts[i]);
            }
                else if (resources[i].tag == "Farm")
            {
                foodSlider.setMaxValue(2 * initResourceAmts[i] + 10);
                foodText.setNumber(initResourceAmts[i]);
            }
            else if (resources[i].tag == "River")
            {
                waterSlider.setMaxValue(2 * initResourceAmts[i] + 10);
                waterText.setNumber(initResourceAmts[i]);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //times += Time.deltaTime;
        //if (times >= 1)
        //{
        //    times = 0;
        for (int i = 0; i < resources.Length; i++)
        {
            //Debug.Log(resources[i].tag + " : " + resourceAmounts[i]);
            if (resources[i].tag == "House" && resourceAmounts[i] <= 0)
            {
                //lose game
                Time.timeScale = 0;
                loseLevel.SetActive(true);
            }
            else if (resources[i].tag == "House" && resourceAmounts[i] > 2 * initResourceAmts[i] + 10)
            {
                //win game
                Time.timeScale = 0;
                winLevel.SetActive(true);
            }
        }
        
    }
    public void decrementResource(string resourceTag, float amount)
    {
        int i;
        for (i = 0; Time.timeScale != 0 && i < numResources; i++)
        {
            if (resources[i].tag == resourceTag)
            {
                //Debug.Log( "In decrement resource" + resourceTag );
                resourceAmounts[i] -= amount;

                handleResources(i);
                break;
            }
        }
        
    }
    
    public void incrementResource(string resourceTag, float amount)
    {
        int i;
        for (i = 0; Time.timeScale != 0 && i < numResources; i++)
        {
            if (resources[i].tag == resourceTag)
            {
                //Debug.Log( "In increment resource" + resourceTag );
                resourceAmounts[i] += amount;
                handleResources(i);
                break;
                
            }
        }        
        
    }
    void handleResources(int i)
    {
        if (resourceAmounts[i] < 0)
        {
            resourceAmounts[i] = 0;
        }
        if (resourceAmounts[i] >= 2 * initResourceAmts[i] + 10)
        {
            resourceAmounts[i] = 2 * initResourceAmts[i] + 10;
        }
        if (resources[i].tag == "House")
        {
            populationSlider.setSliderValue(resourceAmounts[i]);
            populationText.setNumber(resourceAmounts[i]);
        }
        else if (resources[i].tag == "Farm")
        {
            foodSlider.setSliderValue(resourceAmounts[i]);
            foodText.setNumber(resourceAmounts[i]);
        }
        else if (resources[i].tag == "River")
        {
            waterSlider.setSliderValue(resourceAmounts[i]);
            waterText.setNumber(resourceAmounts[i]);
        }
    }
    public float getResourceAmount(string resourceTag)
    {
        int i;
        for (i = 0; i < numResources; i++)
        {
            if (resources[i].tag == resourceTag)
            {
                return resourceAmounts[i];
            }
        }
        return -1;
    }
    public void setActiveResource(GameObject resource)
    {
        if (!canPickupResource())
            return;
        activeResource = resource;
        if (resource.tag == "Farm")
        {
            cursor.makeSteak();
        }
        else if (resource.tag == "River")
        {
            cursor.makeWater();
        }
    }
    public void removeActiveResource()
    {
        activeResource = null;
        cursor.makeDefault();
    }
    public bool canPickupResource()
    {
        if (activeResource == null && Time.timeScale != 0)
            return true;
        return false;
    }

    public GameObject getActiveResource()
    {
        return activeResource;
    }
}
