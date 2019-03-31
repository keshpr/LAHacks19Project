using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{

    public GameObject MainCamera;
    public GameObject[] POPUP;
    public float POPUP_OFFSET = 10;
    public GameObject[] requiredResources;
    public float[] decrementRate;
    public float[] initAmount;
    public float[] currentAmount;
    public const int THRESHOLD = 2;
    private int numResources;
    private bool[] hasPopupAppeared = new bool[2];
    
    private GameObject[] popup;
    GameControllerScript gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        popup = new GameObject[2];
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
            
            //Debug.Log( currentAmount[i] );
            
            if ( currentAmount[i] < THRESHOLD && !hasPopupAppeared[i] ){
                
                popup[i] = Instantiate( POPUP[i], new Vector3(transform.position.x + (i * 30), transform.position.y + POPUP_OFFSET, transform.position.z) , Quaternion.identity);
                
                hasPopupAppeared[i] = true;
            
                //Making the popup look at main camera code
                Vector3 lookPoint = popup[i].transform.position - MainCamera.transform.position;
                lookPoint.y = MainCamera.transform.position.y;
                popup[i].transform.LookAt( lookPoint );
            
            }
            
        }
    }
    
    //If Mouse pressed on the object check what is the currentActiveResource and if it matches then remake the value of currentAmount.
    public void OnMouseDown(){
        Debug.Log("Mouse on unit");
        GameObject activeResource = gameController.getActiveResource();
        if ( activeResource == null ){
            return;
        }
        
        for ( int i = 0; i < numResources; i++ ){
            if ( activeResource.tag == requiredResources[i].tag ){
                gameController.decrementResource(activeResource.tag, initAmount[i] - currentAmount[i]);
                currentAmount[i] = initAmount[i];
                if (this.gameObject.tag == "House")
                {
                    this.gameObject.GetComponent<ResourceScript>().resetDecrRate();
                }
                Destroy(popup[i]);
                hasPopupAppeared[i] = false;

            }
        }
    }

}