using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHandler : MonoBehaviour
{
    // Object in a collision
    public GameObject collidingObj;

    // Object we are already holding
    public GameObject objInHand;

    // Making the controller
    private SteamVR_TrackedObject conObj;
    private SteamVR_Controller.Device Con
    {
        get{
            return SteamVR_Controller.Input((int)conObj.index);
        }
    }


    private void Awake()
    {
        conObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* If the grip button is pressed and released,
         * release the object we are currently holding,
         * or, if we aren't holding anything, grab the
         * object we are touching.*/
        if (Con.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            if (collidingObj && !objInHand)
            {
                GrabObject();
            }

            else if (objInHand)
            {
                ReleaseObject();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObj = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        collidingObj = null;
    }

    private void GrabObject()
    {
        objInHand = collidingObj;
        objInHand.transform.SetParent(this.transform);
        objInHand.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void ReleaseObject()
    {
        objInHand.GetComponent<Rigidbody>().isKinematic = false;
        objInHand.transform.SetParent(null);
        objInHand = null;
    }
}
