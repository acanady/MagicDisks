using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClick : MonoBehaviour
{
    int inventory = 0;
    RaycastHit hit;
    RaycastHit place;
    GameObject heldObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (inventory == 0)
            {
                //casts ray to the object and saves it in heldObject
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                Physics.Raycast(ray, out hit, 100.0f);
                if (hit.transform != null)
                {
                    heldObject = hit.transform.gameObject;
                    
                    inventory = 1;
                }
            }
        }

        //instantiates that object in a new location dependent on the raycast
        if (Input.GetMouseButtonDown(1))
        {
            
            if (inventory == 1)
            {
                Ray placeRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(placeRay, out place);
                if (place.transform != null)
                {
                    print(hit.transform.gameObject.name);
                    
                    Instantiate(heldObject,place.point, Quaternion.identity);
                    Destroy(heldObject);
                }
                inventory = 0;
            }
        }

    }
}