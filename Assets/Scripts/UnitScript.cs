using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{

    public GameObject[] resources;
    public float[] decrementRate;
    public float[] initAmount;
    public float[] currentAmount;
    private int numResources;
    
    GameControllerScript gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        numResources = currentAmount.Length;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        
        for ( int i = 0; i < numResources; i++ ){
            currentAmount[i] = initAmount[i];
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        for ( int i = 0; i < numResources; i++ )
            currentAmount[i] -= decrementRate[i] * Time.deltaTime;
    }
    
    //If Mouse pressed on the object check what is the currentActiveResource and if it matches then remake the value of currentAmount.
    void onMouseDown(){
        GameObject activeResource = gameController.getActiveResource();
        if ( activeResource == null ){
            return;
        }
        
        for ( int i = 0; i < numResources; i++ ){
            if ( activeResource.tag == resources[i].tag ){
                currentAmount[i] = initAmount[i];
            }
        }
    }

}