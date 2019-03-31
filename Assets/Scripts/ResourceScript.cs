using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScript : MonoBehaviour
{
    public float incrRate = 0.5f;
    public float decrRateMax = 2;
    float decrRate;
    GameControllerScript gameController;
    public float[] minDependentAmounts;
    public GameObject[] dependentResources;
    float[] dependentCurrAmt;
    UnitScript unitScript;
    // Start is called before the first frame update
    void Start()
    {
        decrRate = 0;
        unitScript = this.gameObject.GetComponent<UnitScript>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        dependentCurrAmt = new float[dependentResources.Length];
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("Mouse down");
        //}
        int flag = 0;
        for (int i = 0; unitScript != null && i < unitScript.requiredResources.Length; i++)
        {
            for (int j = 0; j < dependentResources.Length; j++)
            {
                if (unitScript.requiredResources[i].tag == dependentResources[j].tag)
                {
                    if (unitScript.currentAmount[i] <= minDependentAmounts[j])
                    {
                        flag = 1;
                        if(this.gameObject.tag == "House")
                            decrRate = decrRateMax;
                    }
                    break;
                }
                if (flag == 1)
                    break;
            }
            
        }
        if (flag == 0 || decrRate > incrRate)
        {
            float amount = Time.deltaTime * (incrRate - decrRate);
            // amount can be negative too, takes care of decreasing the resource, but there is also a separate decreaseResource function
            // in GameController, redundant but ok
            gameController.incrementResource(this.gameObject.tag, amount);
        }
        
    }
    public void resetDecrRate()
    {
        decrRate = 0;
    }
    public void OnMouseDown()
    {
        Debug.Log("Mouse on resource");
        gameController.setActiveResource(this.gameObject);
    }

}
