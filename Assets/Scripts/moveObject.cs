using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObject : MonoBehaviour
{
    GameObject heldObject;
    RaycastHit hit;
    bool carrying = false;

    void Update()
    {
        if (carrying)
        {
            carry(heldObject);
        }

        else if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out hit, 100.0f);
            if (hit.transform != null)
            {
                heldObject = hit.transform.gameObject; //Select clicked on object
                print(heldObject.name);
                carrying = true;
              
            }
        }
    }

    void carry (GameObject carrier)
    {
        Vector3 offset = new Vector3(0, 1, 0);
        
        carrier.transform.position = Vector3.Lerp(carrier.transform.position, Camera.main.transform.position + Camera.main.transform.forward * 3 - offset, Time.deltaTime * 15);
    }
}
