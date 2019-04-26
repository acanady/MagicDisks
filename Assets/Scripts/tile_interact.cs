using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tile_interact : MonoBehaviour
{
    public GameObject UI; //IO panel UI
    public GameObject tilebag; //tilebag UI
    public GameObject tile; // UI button for the specific tile
    public GameObject discGUI; //The Disc GUI 
    public GameObject signalUI; //The UI that dictates the signal of the tile


    //Settings derived from tile interat that are used to create the tile object in the DiscHandler class
    public int signal_strength; //The strength of the signal tile
    public Tile.tile_location location; //The location of the tile on the board it's a struct with an i and a j value
    public string tile_type; //The string for the type of tile they are flow,if,and switch
    public Tile.signal tile_signal; //The signal for the tile at this location
    public Tile.signal signal_data; //used to initalize signal data for the tile
    public Dictionary<string, Tile.signal> sides; //sets up the signals for the tile location
    public int tile_if_type = 0; //the type of the if tile



    public GameObject Disc; //The disc that the tiles are on

    private bool open = false;
    
    public GameObject tile_east_io;
    public GameObject tile_west_io;
    public GameObject tile_south_io;
    public GameObject tile_north_io;
    private GameObject ui_north_io;
    private GameObject ui_south_io;
    private GameObject ui_east_io;
    private GameObject ui_west_io;

    private bool equals;
    private bool not_equal;
    private bool great;
    private bool less;
    private bool less_equals;
    private bool great_equals;
    private bool selected;
    private bool switch_on;
    private bool switch_off;
    private bool flow;
    private bool delete;

    public bool anyUIOpen; //In the case of any tiles NSWE UI being open, that tiles UI doesn't open

    public Sprite noputIMG;
    public Sprite inputIMG;
    public Sprite outputIMG;

    public AudioClip click;
    public AudioClip click2;
    public AudioSource source;

    void Start()
    {
        signal_data = new Tile.signal(0, -1);
        sides = new Dictionary<string, Tile.signal>
        {
            {"north",signal_data},
            { "south",signal_data},
            { "west",signal_data},
            { "east",signal_data},
        };

        print("hello inside the tile_interact script");

        tile_north_io.GetComponent<Image>().enabled = false;
        tile_south_io.GetComponent<Image>().enabled = false;
        tile_east_io.GetComponent<Image>().enabled = false;
        tile_west_io.GetComponent<Image>().enabled = false;

        equals = tilebag.GetComponent<tile_choose>().sel_equals;
        not_equal = tilebag.GetComponent<tile_choose>().sel_not_equals;
        great = tilebag.GetComponent<tile_choose>().sel_great;
        less = tilebag.GetComponent<tile_choose>().sel_less;
        less_equals = tilebag.GetComponent<tile_choose>().sel_less_equals;
        great_equals = tilebag.GetComponent<tile_choose>().sel_great_equals;


        selected = tilebag.GetComponent<tile_choose>().selected;

        source.clip = click;

        if (this.name == "11")
        {
            location = array_map(11);
        }

        if (this.name == "13")
        {
            location = array_map(13);
        }

        if (this.name == "17")
        {
            location = array_map(17);
        }
    }

    public void openUI()
    {
        selected = tilebag.GetComponent<tile_choose>().selected;

        //Goes through the different children of the DiscGUI which are the different tiles and closese there NSWE UI
        for (int i = 0; i <= 24; i++)
        {
            if (discGUI.transform.GetChild(i).name != this.name)
            {
                discGUI.transform.GetChild(i).gameObject.GetComponent<tile_interact>().closeUI();
            }
            else
            {
                print("tile UI not closed in loop is " + this.name);
            }
            //print(discGUI.transform.GetChild(i).name);
        }

        if (!open && !selected)
        {
            UI.SetActive(true);
            if(signalUI != null)
            signalUI.SetActive(true);
            open = true;
 
        }
        else
        {
            UI.SetActive(false);
            if (signalUI != null)
            signalUI.SetActive(false);
            open = false;
        }
        
    }

    public void closeUI()
    {
        UI.SetActive(false);
        open = false;
    }

   public void setInputOutput()
    {

        if (open)
        {
            ui_north_io = UI.transform.GetChild(0).gameObject;
            ui_south_io = UI.transform.GetChild(1).gameObject;
            ui_east_io = UI.transform.GetChild(2).gameObject;
            ui_west_io = UI.transform.GetChild(3).gameObject;

            //Takes the current sprite tile io color and sets it to the N,S,E,W UI
            ui_north_io.GetComponent<Image>().sprite = tile_north_io.GetComponent<Image>().sprite;
            ui_south_io.GetComponent<Image>().sprite = tile_south_io.GetComponent<Image>().sprite;
            ui_east_io.GetComponent<Image>().sprite = tile_east_io.GetComponent<Image>().sprite;
            ui_west_io.GetComponent<Image>().sprite = tile_west_io.GetComponent<Image>().sprite;

            
        }
    }

    public void tile_selection()
    {
        //checks the tilebag tile_choose script to see if that tile has just been selected by the player if so then it updates the
        //boolean value associated with it
        //This value is then used to place the tile. Since selected is set to false immediately after placement and tile_choose sets to
        // false all tiles when selected is false, no more than one tile can be selected at once

        equals = tilebag.GetComponent<tile_choose>().sel_equals;
        not_equal = tilebag.GetComponent<tile_choose>().sel_not_equals;
        great_equals = tilebag.GetComponent<tile_choose>().sel_great_equals;
        less_equals = tilebag.GetComponent<tile_choose>().sel_less_equals;
        less = tilebag.GetComponent<tile_choose>().sel_less;
        great = tilebag.GetComponent<tile_choose>().sel_great;
        switch_on = tilebag.GetComponent<tile_choose>().sel_switch_on;
        switch_off = tilebag.GetComponent<tile_choose>().sel_switch_off;
        flow = tilebag.GetComponent<tile_choose>().sel_flow;
        delete = tilebag.GetComponent<tile_choose>().sel_delete;


        selected = tilebag.GetComponent<tile_choose>().selected;

       // print("clicked on the button fam");

       

        if (selected)
        {
            //prints out the information for the tile when selected
            int val_loc = int.Parse(this.name);
            location = array_map(val_loc);
            print("tile location is " + this.name);
            print("array location x: " + location.i);
            print("array location y: " + location.j);

            source.clip = click2;
            if (equals)
            {
                print("equals tile has been placed");
                tile.gameObject.GetComponent<Image>().sprite = tilebag.transform.GetChild(0).gameObject.GetComponent<Image>().sprite;
                tilebag.GetComponent <tile_choose>().selected = false;
                
                //sets the tile type and the if tile type for creation of the tile itself at that location in the DiscHandler
                tile_type = "if";
                tile_if_type = 4;

                //source.Play();

            }

            if (not_equal)
            {
                print("not equals tile has been placed");
                tile.gameObject.GetComponent<Image>().sprite = tilebag.transform.GetChild(1).gameObject.GetComponent<Image>().sprite;
                tilebag.GetComponent<tile_choose>().selected = false;
                tile_type = "if";
                tile_if_type = 5;
                //source.Play();
            }

            if (switch_on)
            {
                print("switch on tile has been placed");
                tile.gameObject.GetComponent<Image>().sprite = tilebag.transform.GetChild(6).gameObject.GetComponent<Image>().sprite;
                tilebag.GetComponent<tile_choose>().selected = false;
                //source.Play();

            }

            if (switch_off)
            {
                print("switch off tile has been placed");
                tile.gameObject.GetComponent<Image>().sprite = tilebag.transform.GetChild(7).gameObject.GetComponent<Image>().sprite;
                tilebag.GetComponent<tile_choose>().selected = false;
                //source.Play();
            }

            if (great_equals)
            {
        
                print("greater than equals tile has been placed");
                tile.gameObject.GetComponent<Image>().sprite = tilebag.transform.GetChild(2).gameObject.GetComponent<Image>().sprite;
                tilebag.GetComponent<tile_choose>().selected = false;
                tile_type = "if";
                tile_if_type = 3;
                //source.Play();
            }

            if (less_equals)
            {
                print("less than equals tile has been placed");
                tile.gameObject.GetComponent<Image>().sprite = tilebag.transform.GetChild(3).gameObject.GetComponent<Image>().sprite;
                tilebag.GetComponent<tile_choose>().selected = false;
                tile_type = "if";
                tile_if_type = 2;
                //source.Play();
            }

            if (less)
            {
                print("less than tile has been placed");
                tile.gameObject.GetComponent<Image>().sprite = tilebag.transform.GetChild(4).gameObject.GetComponent<Image>().sprite;
                tilebag.GetComponent<tile_choose>().selected = false;
                tile_type = "if";
                tile_if_type = 0;
                //source.Play();
            }

            if (great)
            {
                print("greater than tile has been placed");
                tile.gameObject.GetComponent<Image>().sprite = tilebag.transform.GetChild(5).gameObject.GetComponent<Image>().sprite;
                tilebag.GetComponent<tile_choose>().selected = false;
                tile_type = "if";
                tile_if_type = 1;
                //source.Play();
            }

            if (flow)
            {
                print("flow tile has been placed");
                tile.gameObject.GetComponent<Image>().sprite = tilebag.transform.GetChild(8).gameObject.GetComponent<Image>().sprite;
                tilebag.GetComponent<tile_choose>().selected = false;
                //source.Play();
            }

            if (delete)
            {
                print("delete tile selected");
                tile.gameObject.GetComponent<Image>().sprite = noputIMG;
                tilebag.GetComponent<tile_choose>().selected = false;
                //source.Play();
            }
        }
    }

    public void setNorthIO()
    {
        source.clip = click;
        source.Play();
        if (ui_north_io != null)
        {
            if(ui_north_io.GetComponent<Image>().sprite.name == "noput")
            {
                ui_north_io.GetComponent<Image>().sprite = inputIMG;
                tile_north_io.GetComponent<Image>().sprite = ui_north_io.GetComponent<Image>().sprite;
                tile_north_io.GetComponent<Image>().enabled = true;

                //in this case we're currently inputing from the tile so we set the north side input to 0
                tile_signal = new Tile.signal(signal_strength, 0);
                sides["north"] = tile_signal;
            }

            else if (ui_north_io.GetComponent<Image>().sprite.name == "input")
            {
                ui_north_io.GetComponent<Image>().sprite = outputIMG;
                tile_north_io.GetComponent<Image>().sprite = ui_north_io.GetComponent<Image>().sprite;
                tile_north_io.GetComponent<Image>().enabled = true;

                //in this case we're currently outputing form the tile so we set the north side input to 1
                tile_signal = new Tile.signal(signal_strength, 1);
                sides["north"] = tile_signal;
            }

            else if (ui_north_io.GetComponent<Image>().sprite.name == "output")
            {
                ui_north_io.GetComponent<Image>().sprite = noputIMG;
                tile_north_io.GetComponent<Image>().sprite = ui_north_io.GetComponent<Image>().sprite;
                tile_north_io.GetComponent<Image>().enabled = false;

                //in this case we have no output or input so we set north side input to -1

                tile_signal = new Tile.signal(signal_strength, -1);
                sides["north"] = tile_signal;
            }
            else
            {
                print(ui_north_io.GetComponent<Image>().sprite.name);
            }
        }

        else
        {
            print("TILE IS NULL");
        }
    }

    public void setSouthIO()
    {
        source.clip = click;
        source.Play();
        if (ui_south_io != null)
        {
            
            //if the current sprite name set for the south side is noput then it cycles it to input and sets the
            //input/output image of the tile
            if (ui_south_io.GetComponent<Image>().sprite.name == "noput")
            {
                ui_south_io.GetComponent<Image>().sprite = inputIMG;
                tile_south_io.GetComponent<Image>().sprite = ui_south_io.GetComponent<Image>().sprite;
                tile_south_io.GetComponent<Image>().enabled = true;

                //in this case we're currently inputing from the tile so we set the south side input to 0
                tile_signal = new Tile.signal(signal_strength, 0);
                sides["south"] = tile_signal;
            }

            //if the current sprite name set for the south side is input then it cycles it to output and sets the
            //input/output image of the tile
            else if (ui_south_io.GetComponent<Image>().sprite.name == "input")
            {
                ui_south_io.GetComponent<Image>().sprite = outputIMG;
                tile_south_io.GetComponent<Image>().sprite = ui_south_io.GetComponent<Image>().sprite;
                tile_south_io.GetComponent<Image>().enabled = true;

                //in this case we're currently outputing form the tile so we set the south side input to 1
                tile_signal = new Tile.signal(signal_strength, 1);
                sides["south"] = tile_signal;
            }

            //if the current sprite name set for the south side is output then it cycles it to noput and sets the
            //input/output image of the tile
            else if (ui_south_io.GetComponent<Image>().sprite.name == "output")
            {
                ui_south_io.GetComponent<Image>().sprite = noputIMG;
                tile_south_io.GetComponent<Image>().sprite = ui_south_io.GetComponent<Image>().sprite;
                tile_south_io.GetComponent<Image>().enabled = false;

                //in this case we have no output or input so we set south side input to -1

                tile_signal = new Tile.signal(signal_strength, -1);
                sides["south"] = tile_signal;
            }

            //error detection
            else
            {
                print("Error at" + ui_south_io.GetComponent<Image>().sprite.name);
            }
        }

        //error detection
        else
        {
            print("TILE IS NULL");
        }

    }

    public void setEastIO()
    {
        source.clip = click;
        source.Play();
        if (ui_east_io != null)
        {
            if (ui_east_io.GetComponent<Image>().sprite.name == "noput")
            {
                ui_east_io.GetComponent<Image>().sprite = inputIMG;
                tile_east_io.GetComponent<Image>().sprite = ui_east_io.GetComponent<Image>().sprite;
                tile_east_io.GetComponent<Image>().enabled = true;

                //in this case we're currently inputing from the tile so we set the east side input to 0
                tile_signal = new Tile.signal(signal_strength, 0);
                sides["east"] = tile_signal;
            }

            else if (ui_east_io.GetComponent<Image>().sprite.name == "input")
            {
                ui_east_io.GetComponent<Image>().sprite = outputIMG;
                tile_east_io.GetComponent<Image>().sprite = ui_east_io.GetComponent<Image>().sprite;
                tile_east_io.GetComponent<Image>().enabled = true;

                //in this case we're currently outputing form the tile so we set the east side input to 1
                tile_signal = new Tile.signal(signal_strength, 1);
                sides["east"] = tile_signal;
            }

            else if (ui_east_io.GetComponent<Image>().sprite.name == "output")
            {
                ui_east_io.GetComponent<Image>().sprite = noputIMG;
                tile_east_io.GetComponent<Image>().sprite = ui_east_io.GetComponent<Image>().sprite;
                tile_east_io.GetComponent<Image>().enabled = false;

                //in this case we have no output or input so we set east side input to -1

                tile_signal = new Tile.signal(signal_strength, -1);
                sides["east"] = tile_signal;
            }
            else
            {
                print(ui_east_io.GetComponent<Image>().sprite.name);
            }
        }

        else
        {
            print("TILE IS NULL");
        }
    }

    public void setWestIO()
    {
        source.clip = click;
        source.Play();
        if (ui_west_io != null)
        {
            if (ui_west_io.GetComponent<Image>().sprite.name == "noput")
            {
                ui_west_io.GetComponent<Image>().sprite = inputIMG;
                tile_west_io.GetComponent<Image>().sprite = ui_west_io.GetComponent<Image>().sprite;
                tile_west_io.GetComponent<Image>().enabled = true;

                //in this case we're currently inputing from the tile so we set the west side input to 0
                tile_signal = new Tile.signal(signal_strength, 0);
                sides["west"] = tile_signal;
            }

            else if (ui_west_io.GetComponent<Image>().sprite.name == "input")
            {
                ui_west_io.GetComponent<Image>().sprite = outputIMG;
                tile_west_io.GetComponent<Image>().sprite = ui_west_io.GetComponent<Image>().sprite;
                tile_west_io.GetComponent<Image>().enabled = true;

                //in this case we're currently outputing form the tile so we set the weest side input to 1
                tile_signal = new Tile.signal(signal_strength, 1);
                sides["west"] = tile_signal;
            }


            else if (ui_west_io.GetComponent<Image>().sprite.name == "output")
            {
                ui_west_io.GetComponent<Image>().sprite = noputIMG;
                tile_west_io.GetComponent<Image>().sprite = ui_west_io.GetComponent<Image>().sprite;
                tile_west_io.GetComponent<Image>().enabled = false;

                //in this case we have no output or input so we set west side input to -1

                tile_signal = new Tile.signal(signal_strength, -1);
                sides["west"] = tile_signal;
            }
            else
            {
                print(ui_west_io.GetComponent<Image>().sprite.name);
            }
        }

        else
        {
            print("TILE IS NULL");
        }
    }

    public void signal1()
    {
        Sprite signal1 = signalUI.transform.GetChild(0).gameObject.GetComponent<Image>().sprite;
        Sprite signal2 = signalUI.transform.GetChild(1).gameObject.GetComponent<Image>().sprite;
        Sprite signal3 = signalUI.transform.GetChild(2).gameObject.GetComponent<Image>().sprite;

        //so if the sprite there is the ouputIMG, the purple one then a signal has been set for that tile already
        if (signal1.name == outputIMG.name)
        {
            signalUI.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = noputIMG;
            signal_strength = 0;

            //After updating the signal strength every side of the tile has it's signal strength changed to match
            sides["north"] = new Tile.signal(signal_strength, sides["north"].inout);
            sides["south"] = new Tile.signal(signal_strength, sides["south"].inout);

            sides["east"] = new Tile.signal(signal_strength, sides["east"].inout);
            sides["west"] = new Tile.signal(signal_strength, sides["west"].inout);
        }

        //similar, it swpas the image and resets the signal strenth
        if(signal1.name == noputIMG.name)
        {
            signalUI.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = outputIMG;
            signal_strength = 1;

            //After updating the signal strength every side of the tile has it's signal strength changed to match
            sides["north"] = new Tile.signal(signal_strength, sides["north"].inout);
            sides["south"] = new Tile.signal(signal_strength, sides["south"].inout);

            sides["east"] = new Tile.signal(signal_strength, sides["east"].inout);
            sides["west"] = new Tile.signal(signal_strength, sides["west"].inout);
        }

        //Also if the other tiles UI needs to be set to noputIMG;
        signalUI.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = noputIMG;
        signalUI.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = noputIMG;

    }

    public void signal2()
    {
        Sprite signal2 = signalUI.transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

        if (signal2.name == outputIMG.name)
        {
            signalUI.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = noputIMG;
            //signalUI.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = noputIMG;
            signal_strength = 1;

            ///After updating the signal strength every side of the tile has it's signal strength changed to match
            sides["north"] = new Tile.signal(signal_strength, sides["north"].inout);
            sides["south"] = new Tile.signal(signal_strength, sides["south"].inout);

            sides["east"] = new Tile.signal(signal_strength, sides["east"].inout);
            sides["west"] = new Tile.signal(signal_strength, sides["west"].inout);
        }

        if(signal2.name == noputIMG.name)
        {
            signalUI.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = outputIMG;
            signalUI.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = outputIMG;
            signal_strength = 2;

            //After updating the signal strength every side of the tile has it's signal strength changed to match
            sides["north"] = new Tile.signal(signal_strength, sides["north"].inout);
            sides["south"] = new Tile.signal(signal_strength, sides["south"].inout);

            sides["east"] = new Tile.signal(signal_strength, sides["east"].inout);
            sides["west"] = new Tile.signal(signal_strength, sides["west"].inout);

        }

        signalUI.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = noputIMG;


    }

    public void signal3()
    {
        Sprite signal3 = signalUI.transform.GetChild(2).gameObject.GetComponent<Image>().sprite;

        if(signal3.name == outputIMG.name)
        {
            signalUI.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = noputIMG;
            signal_strength = 2;

            //After updating the signal strength every side of the tile has it's signal strength changed to match
            sides["north"] = new Tile.signal(signal_strength, sides["north"].inout);
            sides["south"] = new Tile.signal(signal_strength, sides["south"].inout);

            sides["east"] = new Tile.signal(signal_strength, sides["east"].inout);
            sides["west"] = new Tile.signal(signal_strength, sides["west"].inout);
        }

        if(signal3.name == noputIMG.name)
        {
            signalUI.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = outputIMG;
            signalUI.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = outputIMG;
            signalUI.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = outputIMG;
            signal_strength = 3;

            //After updating the signal strength every side of the tile has it's signal strength changed to match
            sides["north"] = new Tile.signal(signal_strength, sides["north"].inout);
            sides["south"] = new Tile.signal(signal_strength, sides["south"].inout);

            sides["east"] = new Tile.signal(signal_strength, sides["east"].inout);
            sides["west"] = new Tile.signal(signal_strength, sides["west"].inout);
        }
    }
    //the tile slots have numbers from 0 to 24 it's a 1D array so to speak. This function takes in a number from the 1D array and returns the two array values
    public Tile.tile_location array_map(int val)
    {
        Tile.tile_location my_loc;
        int x = val / 5;
        int y = val % 5;

        my_loc.i = x;
        my_loc.j = y;

        return my_loc;

    }
}
