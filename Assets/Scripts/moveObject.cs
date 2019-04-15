using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObject : MonoBehaviour
{
    GameObject heldObject;
    RaycastHit hit;
    bool carrying = false;
    bool pickup = false;
   

    void Update()
    {
        
        if (carrying && pickup)
        {
            carry(heldObject);
        }

        else if (Input.GetMouseButtonDown(0))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(x,y));

            Physics.Raycast(ray, out hit, 100.0f);
            if (hit.transform != null)
            {
                heldObject = hit.transform.gameObject; //Select clicked on object
                print(heldObject.name);
                pickup = heldObject.GetComponent<pickupable>().pickup;
                carrying = true;
              
            }
        }

        if (carrying == true && Input.GetMouseButtonDown(1))
        {
            print("Dropping object");
            drop(heldObject);
        }
    }

    void carry (GameObject carrier) 
    {

        Rigidbody rb = carrier.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        Vector3 offset = new Vector3(0, 1, 0);
        
        carrier.transform.position = Vector3.Lerp(carrier.transform.position, Camera.main.transform.position + Camera.main.transform.forward * 3 - offset, Time.deltaTime * 15);
    }

    void drop (GameObject carrier)
    {
        Rigidbody rb = carrier.GetComponent<Rigidbody>();
        carrying = false;
        rb.isKinematic = false;
    }
}
