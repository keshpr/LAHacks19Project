using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScript : MonoBehaviour
{
    public float incrRate;
    GameControllerScript gameController;
    public GameObject[] dependentResources;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float amount = Time.deltaTime * incrRate;
        gameController.incrementResource(this.gameObject.tag, amount);
    }

    void onMouseDown()
    {
        gameController.setActiveResource(this.gameObject);
    }

}
