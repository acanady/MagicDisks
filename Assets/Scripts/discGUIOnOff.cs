using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class discGUIOnOff : MonoBehaviour
{
    RaycastHit hit;
    public bool guiEnabled = false;
    public GameObject discGUI;
    //public GameObject IOGUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //casts ray to the object to see if it has been clicked on
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, 100.0f);

            // If the disc is clicked on then the Disc GUI is brought up
        if (hit.transform != null)
            {
                print(hit.transform.tag);
                if (hit.transform.tag == "disc" && !guiEnabled)
                {
                    guiEnabled = true;
                }
            }
        }

        if (guiEnabled)
        {
            discGUI.SetActive(true);
        }

        //If I is clicked then the gui is disabled
        if (Input.GetKeyDown(KeyCode.I))
        {
            guiEnabled = false;
            discGUI.SetActive(false);
            //IOGUI.SetActive(false);
   
        }
        
    }
}
