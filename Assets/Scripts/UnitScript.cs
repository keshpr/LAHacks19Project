using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{

    
    public GameObject POPUP;
    public float POPUP_OFFSET = 10;
    public GameObject[] requiredResources;
    public float[] decrementRate;
    public float[] initAmount;
    public float[] currentAmount;
    private const int THRESHOLD = 10;
    private int numResources;
    private bool hasPopupAppeared = false; 
    
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
        for ( int i = 0; i < numResources; i++ ){
            
            currentAmount[i] -= decrementRate[i] * Time.deltaTime;
            
            if ( currentAmount[i] < 0 ){
                currentAmount[i] = 0;
            }
            
            Debug.Log( currentAmount[i] );
            
            if ( currentAmount[i] < THRESHOLD && !hasPopupAppeared ){
                Instantiate( POPUP, new Vector3(transform.position.x, transform.position.y + POPUP_OFFSET, transform.position.z) , Quaternion.identity);
                hasPopupAppeared = true;
            }
            
        }
    }
    
    //If Mouse pressed on the object check what is the currentActiveResource and if it matches then remake the value of currentAmount.
    void onMouseDown(){
        GameObject activeResource = gameController.getActiveResource();
        if ( activeResource == null ){
            return;
        }
        
        for ( int i = 0; i < numResources; i++ ){
            if ( activeResource.tag == requiredResources[i].tag ){
                currentAmount[i] = initAmount[i];
            }
        }
    }

}