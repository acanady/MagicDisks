using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tile_choose : MonoBehaviour
{
    public Rigidbody controller;
    public GameObject DiscGUI;
    public bool selected;

    //These boolean values are true if the tile has been picked up
    //less = if less than tile... etc.
    //These never change after being set and again, only do so when the tile has been picked up

    bool less;
    bool great;
    bool equals;
    bool less_equals;
    bool great_equals;
    bool not_equals;
    bool switch_on;
    bool switch_off;
    bool flow;
    bool delete;

    //boolean values for whether the button was selected for the specific if tile
    //if it is then it's necessary so that DiscGUI can access that value when the DiscGUI button is clicked
    public bool sel_less;
    public bool sel_great;
    public bool sel_equals;
    public bool sel_less_equals;
    public bool sel_great_equals;
    public bool sel_not_equals;
    public bool sel_switch_on;
    public bool sel_switch_off;
    public bool sel_flow;
    public bool sel_delete;

    // Start is called before the first frame update
    void Start()
    {
        //Code no longer necessary
        //less = controller.gameObject.GetComponent<tile_inventory>().less;
        //reat = controller.gameObject.GetComponent<tile_inventory>().great;
        //equals = controller.gameObject.GetComponent<tile_inventory>().equals;
        //less_equals = controller.gameObject.GetComponent<tile_inventory>().less_equals;
        //great_equals = controller.gameObject.GetComponent<tile_inventory>().great_equals;
        //not_equals = controller.gameObject.GetComponent<tile_inventory>().not_equal;
    }

    
    //When pressing on the button, it adds the item to your hidden inventory? It lets you then click on the DiscGUI
    //and it puts it there

    public void select_equals()
    {
        //sets all others to false, could've been done in an array with a loop but at this point I had alreay gone pretty far
        //didn't want to have to deal with that, so here's this nasty code

        sel_great = false;
        sel_great_equals = false;
        sel_less = false;
        sel_less_equals = false;
        sel_not_equals = false;
        sel_equals = false;
        sel_switch_on = false;
        sel_switch_off = false;
        sel_flow = false;
        sel_delete = false;

        equals = controller.gameObject.GetComponent<tile_inventory>().equals;

        print("clicked on select equals");
        //if the quals button was hit then we set selected to true
        if (equals){
            print("if tile has been selected");
            selected = true;
            sel_equals = true;
        }

    }

    public void select_notequals()
    {
        sel_great = false;
        sel_great_equals = false;
        sel_less = false;
        sel_less_equals = false;
        sel_not_equals = false;
        sel_equals = false;
        sel_switch_on = false;
        sel_switch_off = false;
        sel_flow = false;
        sel_delete = false;

        not_equals = controller.gameObject.GetComponent<tile_inventory>().not_equal;

        print("clicked on not equal");
        if (not_equals)
        {
            print("not equals tile has been selected");
            //Selected tells the tile_interact script that something has been selected. sel_not_equals true means that the not equals tile has been selected
            selected = true;
            sel_not_equals = true;
        }
    }

    public void select_greaterequal()
    {
        sel_great = false;
        sel_great_equals = false;
        sel_less = false;
        sel_less_equals = false;
        sel_not_equals = false;
        sel_equals = false;
        sel_switch_on = false;
        sel_switch_off = false;
        sel_flow = false;
        sel_delete = false;

        great_equals = controller.gameObject.GetComponent<tile_inventory>().great_equals;

        if (great_equals)
        {
            print("greater than equal tile has been selected");
            selected = true;
            sel_great_equals = true;
        }
    }

    public void select_lessequal()
    {
        sel_great = false;
        sel_great_equals = false;
        sel_less = false;
        sel_less_equals = false;
        sel_not_equals = false;
        sel_equals = false;
        sel_switch_on = false;
        sel_switch_off = false;
        sel_flow = false;
        sel_delete = false;

        less_equals = controller.gameObject.GetComponent<tile_inventory>().less_equals;

        if (less_equals)
        {
            print("less than equal tile has been selected");
            selected = true;
            sel_less_equals = true;
        }
    }

    public void select_less()
    {
        sel_great = false;
        sel_great_equals = false;
        sel_less = false;
        sel_less_equals = false;
        sel_not_equals = false;
        sel_equals = false;
        sel_switch_on = false;
        sel_switch_off = false;
        sel_flow = false;
        sel_delete = false;

        less = controller.gameObject.GetComponent<tile_inventory>().less;
        if (less)
        {
            print("less than tile has been selected");
            selected = true;
            sel_less = true;
        }
    }

    public void select_great()
    {
        sel_great = false;
        sel_great_equals = false;
        sel_less = false;
        sel_less_equals = false;
        sel_not_equals = false;
        sel_equals = false;
        sel_switch_on = false;
        sel_switch_off = false;
        sel_flow = false;
        sel_delete = false;

        great = controller.gameObject.GetComponent<tile_inventory>().less;
        if (great)
        {
            print("greater than tile has been selected");
            selected = true;
            sel_great = true;
        }
    }

    public void select_switch_on()
    {
        sel_great = false;
        sel_great_equals = false;
        sel_less = false;
        sel_less_equals = false;
        sel_not_equals = false;
        sel_equals = false;
        sel_switch_on = false;
        sel_switch_off = false;
        sel_flow = false;
        sel_delete = false;

        switch_on = controller.gameObject.GetComponent<tile_inventory>().switch_on;

        if (switch_on)
        {
            print("switch on tile has been selected");
            selected = true;
            sel_switch_on = true;
        }
    }

    public void select_switch_off()
    {
        sel_great = false;
        sel_great_equals = false;
        sel_less = false;
        sel_less_equals = false;
        sel_not_equals = false;
        sel_equals = false;
        sel_switch_on = false;
        sel_switch_off = false;
        sel_flow = false;
        sel_delete = false;

        switch_off = controller.gameObject.GetComponent<tile_inventory>().switch_off;

        if (switch_off)
        {
            print("switch off tile has been selected");
            selected = true;
            sel_switch_off = true;
        }

    }

    public void select_flow()
    {
        sel_great = false;
        sel_great_equals = false;
        sel_less = false;
        sel_less_equals = false;
        sel_not_equals = false;
        sel_equals = false;
        sel_switch_on = false;
        sel_switch_off = false;
        sel_flow = false;
        sel_delete = false;

        flow = controller.gameObject.GetComponent<tile_inventory>().flow;

        if (flow)
        {
            print("flow tile has been selected");
            selected = true;
            sel_flow = true;
        }

    }


    public void select_delete()
    {
        sel_great = false;
        sel_great_equals = false;
        sel_less = false;
        sel_less_equals = false;
        sel_not_equals = false;
        sel_equals = false;
        sel_switch_on = false;
        sel_switch_off = false;
        sel_flow = false;
        sel_delete = false;

        delete = controller.gameObject.GetComponent<tile_inventory>().delete;

        if (delete)
        {
            print("deletion tile has been selected");
            selected = true;
            sel_delete = true;
        }

    }

    /*//from the selected tile, once the button on the DiscGUI is clicked, the image for that tile will become the selected tiles image
    void tile_selection()
    {
        if (selected)
        {
            if(less_equals)
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        // in the case that nothing is selected, everything is set to false
        if (selected == false)
        {
            sel_equals = false;
            sel_great = false;
            sel_great_equals = false;
            sel_less = false;
            sel_less_equals = false;
            sel_not_equals = false;
            sel_switch_on = false;
            sel_switch_off = false;
            sel_flow = false;
            sel_delete = false;
        }
    }
}
