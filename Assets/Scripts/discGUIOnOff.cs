using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class discGUIOnOff : MonoBehaviour
{
    public bool guiEnabled = false;
    public GameObject discGUI;
    public GameObject tile_bag;
    public GameObject controller;
    //public GameObject IOGUI;

    // Update is called once per frame
    void Update()
    {
      
        //Checks to see if the computer has been picked up in tile inventory
        //If so the GUI turns on
        if (controller.GetComponent<tile_inventory>().computer)
        {
            discGUI.SetActive(true);
            tile_bag.SetActive(true);
        }
    }
}
