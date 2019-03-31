using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layermask = 1 << 13;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit " + hit.transform.gameObject.tag);
                GameObject gameObject = hit.transform.gameObject;
                ResourceScript r = gameObject.GetComponent<ResourceScript>();
                UnitScript u = gameObject.GetComponent<UnitScript>();
                FloorScript f = gameObject.GetComponent<FloorScript>();
                if (r != null)
                {
                    //r.OnMouseDown2();
                }
                if (u != null)
                {
                    //u.OnMouseDown2();
                }
                if (f != null)
                {
                    //f.OnMouseDown2();
                }
            }
        }
            
    }
}
