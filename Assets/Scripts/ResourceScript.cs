using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScript : MonoBehaviour
{
    public float incrRate;
    public float decrRate = 0;
    GameControllerScript gameController;
    public float[] minDependentAmounts;
    public GameObject[] dependentResources;
    float[] dependentCurrAmt;
    UnitScript unitScript;
    // Start is called before the first frame update
    void Start()
    {
        unitScript = this.gameObject.GetComponent<UnitScript>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        dependentCurrAmt = new float[dependentResources.Length];
    }

    // Update is called once per frame
    void Update()
    {
        int flag = 0;
        for (int i = 0; unitScript != null && i < unitScript.requiredResources.Length; i++)
        {
            for (int j = 0; j < dependentResources.Length; j++)
            {
                if (unitScript.requiredResources[i].tag == dependentResources[j].tag)
                {
                    if (unitScript.currentAmount[i] <= minDependentAmounts[j])
                        flag = 1;
                    break;
                }
                if (flag == 1)
                    break;
            }
            
        }
        if (flag == 0)
        {
            float amount = Time.deltaTime * (incrRate - decrRate);
            // amount can be negative too, takes care of decreasing the resource, but there is also a separate decreaseResource function
            // in GameController, redundant but ok
            gameController.incrementResource(this.gameObject.tag, amount);
        }
        
    }

    void onMouseDown()
    {
        gameController.setActiveResource(this.gameObject);
    }

}
