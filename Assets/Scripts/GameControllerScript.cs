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
    // Start is called before the first frame update
    void Start()
    {
        activeResource = null;
        numResources = resources.Length;
        resourceAmounts = new float[numResources];
        
        for (int i = 0; i < numResources; i++)
        {
            resourceAmounts[i] = initResourceAmts[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void decrementResource(string resourceTag, float amount)
    {
        int i;
        for (i = 0; i < numResources; i++)
        {
            if (resources[i].tag == resourceTag)
            {
                break;
            }
        }
        resourceAmounts[i] -= amount;
    }
    public void incrementResource(string resourceTag, float amount)
    {
        int i;
        for (i = 0; i < numResources; i++)
        {
            if (resources[i].tag == resourceTag)
            {
                break;
            }
        }
        resourceAmounts[i] += amount;
    }

    public void setActiveResource(GameObject resource)
    {
        if (!canPickupResource())
            return;
        activeResource = resource;
    }
    public void removeActiveResource()
    {
        activeResource = null;
    }
    public bool canPickupResource()
    {
        if (activeResource == null)
            return true;
        return false;
    }

    public GameObject getActiveResource()
    {
        return activeResource;
    }
}
