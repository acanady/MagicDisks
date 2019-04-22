using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tile_inventory : MonoBehaviour
{
    public GameObject inventory;

    public bool equals = false; // if equals tile
    public bool less = false; // if less than tile
    public bool great = false; //if greather than tile
    public bool less_equals = false; //if less than or equals tile
    public bool great_equals = false; //if greater than or equals tile
    public bool not_equal = false; //if not equal tile
    public bool switch_on = false; //switch tile
    public bool switch_off = false; //switch tile
    public bool flow = false; //flow tile
    public bool delete = false; //deletion tile

    
    // Update is called once per frame
  
    void OnTriggerEnter(Collider other)
    {
        //Checks collission for what tile was picked up
        switch (other.gameObject.name)
        {
            case "equals":
                print("if equals tile picked up");
                Destroy(other.gameObject);
                equals = true;
                break;

            case "lessequal":
                print("less equals tile picked up");
                Destroy(other.gameObject);
                less_equals = true;
                break;

            case "notequal":
                print("not equal tile picked up");
                Destroy(other.gameObject);
                not_equal = true;
                break;

            case "less":
                print("less than tile picked up");
                Destroy(other.gameObject);
                less = true;
                break;

            case "greater":
                print("greter than tile picked up");
                Destroy(other.gameObject);
                great = true;
                break;

            case "greaterequal":
                print("grater equals picked up");
                Destroy(other.gameObject);
                great_equals = true;
                break;

            case "switchon":
                print("switch on tile picked up");
                Destroy(other.gameObject);
                switch_on = true;
                break;

            case "switchoff":
                print("switch off tile picked up");
                Destroy(other.gameObject);
                switch_off = true;
                break;

            case "flow":
                print("flow tile picked up");
                Destroy(other.gameObject);
                flow = true;
                break;

            case "delete":
                print("delete tile picked up");
                Destroy(other.gameObject);
                delete = true;
                break;

           default:
                print("name of object passed through:" + other.gameObject.name);
                break;
        }
    }

    void Update()
    {
        //Depending on the tile that was picked up it sets the GUI image for that tiles transparency to 100 meaning that the tile is now bright
        if (equals)
        {
            var tempcolor = inventory.transform.GetChild(0).gameObject.GetComponent<Image>().color;
            tempcolor.a = 1f;
            inventory.transform.GetChild(0).gameObject.GetComponent<Image>().color = tempcolor;
            //print("Equals baby");
        }

        if (less)
        {
            var tempcolor = inventory.transform.GetChild(4).gameObject.GetComponent<Image>().color;
            tempcolor.a = 1f;
            inventory.transform.GetChild(4).gameObject.GetComponent<Image>().color = tempcolor;
        }

        if (great)
        {
            var tempcolor = inventory.transform.GetChild(5).gameObject.GetComponent<Image>().color;
            tempcolor.a = 1f;
            inventory.transform.GetChild(5).gameObject.GetComponent<Image>().color = tempcolor;
        }

        if (less_equals)
        {
            var tempcolor = inventory.transform.GetChild(3).gameObject.GetComponent<Image>().color;
            tempcolor.a = 1f;
            inventory.transform.GetChild(3).gameObject.GetComponent<Image>().color = tempcolor;
        }

        if (great_equals)
        {
            var tempcolor = inventory.transform.GetChild(2).gameObject.GetComponent<Image>().color;
            tempcolor.a = 1f;
            inventory.transform.GetChild(2).gameObject.GetComponent<Image>().color = tempcolor;
        }
        if (not_equal)
        {
            var tempcolor = inventory.transform.GetChild(1).gameObject.GetComponent<Image>().color;
            tempcolor.a = 1f;
            inventory.transform.GetChild(1).gameObject.GetComponent<Image>().color = tempcolor;
        }

        if (switch_on)
        {
            var tempcolor = inventory.transform.GetChild(6).gameObject.GetComponent<Image>().color;
            tempcolor.a = 1f;
            inventory.transform.GetChild(6).gameObject.GetComponent<Image>().color = tempcolor;
        }

        if (switch_off)
        {
            var tempcolor = inventory.transform.GetChild(7).gameObject.GetComponent<Image>().color;
            tempcolor.a = 1f;
            inventory.transform.GetChild(7).gameObject.GetComponent<Image>().color = tempcolor;
        }

        if (flow)
        {
            var tempcolor = inventory.transform.GetChild(8).gameObject.GetComponent<Image>().color;
            tempcolor.a = 1f;
            inventory.transform.GetChild(8).gameObject.GetComponent<Image>().color = tempcolor;
        }

        if (delete)
        {
            var tempcolor = inventory.transform.GetChild(9).gameObject.GetComponent<Image>().color;
            tempcolor.a = 1f;
            inventory.transform.GetChild(9).gameObject.GetComponent<Image>().color = tempcolor;
        }
    }
}
