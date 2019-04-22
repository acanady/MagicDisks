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

    void Start()
    {
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
            print(discGUI.transform.GetChild(i).name);
        }

        if (!open && !selected)
        {
            UI.SetActive(true);
            open = true;
 
        }
        else
        {
            UI.SetActive(false);
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
            if (equals)
            {
                print("equals tile has been placed");
                tile.gameObject.GetComponent<Image>().sprite = tilebag.transform.GetChild(0).gameObject.GetComponent<Image>().sprite;
                tilebag.GetComponent <tile_choose>().selected = false;
            }

            if (not_equal)
            {
                print("not equals tile has been placed");
                tile.gameObject.GetComponent<Image>().sprite = tilebag.transform.GetChild(1).gameObject.GetComponent<Image>().sprite;
                tilebag.GetComponent<tile_choose>().selected = false;
            }

            if (great_equals)
            {
        
                print("greater than equals tile has been placed");
                tile.gameObject.GetComponent<Image>().sprite = tilebag.transform.GetChild(2).gameObject.GetComponent<Image>().sprite;
                tilebag.GetComponent<tile_choose>().selected = false;
            }

            if (less_equals)
            {
                print("less than equals tile has been placed");
                tile.gameObject.GetComponent<Image>().sprite = tilebag.transform.GetChild(3).gameObject.GetComponent<Image>().sprite;
                tilebag.GetComponent<tile_choose>().selected = false;
            }

            if (less)
            {
                print("less than tile has been placed");
                tile.gameObject.GetComponent<Image>().sprite = tilebag.transform.GetChild(4).gameObject.GetComponent<Image>().sprite;
                tilebag.GetComponent<tile_choose>().selected = false;
            }

            if (great)
            {
                print("greater than tile has been placed");
                tile.gameObject.GetComponent<Image>().sprite = tilebag.transform.GetChild(5).gameObject.GetComponent<Image>().sprite;
                tilebag.GetComponent<tile_choose>().selected = false;
            }

            if (flow)
            {
                print("flow tile has been placed");
                tile.gameObject.GetComponent<Image>().sprite = tilebag.transform.GetChild(8).gameObject.GetComponent<Image>().sprite;
                tilebag.GetComponent<tile_choose>().selected = false;
            }

            if (delete)
            {
                print("delete tile selected");
                tile.gameObject.GetComponent<Image>().sprite = noputIMG;
                tilebag.GetComponent<tile_choose>().selected = false;
            }
        }
    }

    public void setNorthIO()
    {
        if (ui_north_io != null)
        {
            if(ui_north_io.GetComponent<Image>().sprite.name == "noput")
            {
                ui_north_io.GetComponent<Image>().sprite = inputIMG;
                tile_north_io.GetComponent<Image>().sprite = ui_north_io.GetComponent<Image>().sprite;
                tile_north_io.GetComponent<Image>().enabled = true;
            }

            else if (ui_north_io.GetComponent<Image>().sprite.name == "input")
            {
                ui_north_io.GetComponent<Image>().sprite = outputIMG;
                tile_north_io.GetComponent<Image>().sprite = ui_north_io.GetComponent<Image>().sprite;
                tile_north_io.GetComponent<Image>().enabled = true;
            }

            else if (ui_north_io.GetComponent<Image>().sprite.name == "output")
            {
                ui_north_io.GetComponent<Image>().sprite = noputIMG;
                tile_north_io.GetComponent<Image>().sprite = ui_north_io.GetComponent<Image>().sprite;
                tile_north_io.GetComponent<Image>().enabled = false;
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
        if (ui_south_io != null)
        {
            //if the current sprite name set for the south side is noput then it cycles it to input and sets the
            //input/output image of the tile
            if (ui_south_io.GetComponent<Image>().sprite.name == "noput")
            {
                ui_south_io.GetComponent<Image>().sprite = inputIMG;
                tile_south_io.GetComponent<Image>().sprite = ui_south_io.GetComponent<Image>().sprite;
                tile_south_io.GetComponent<Image>().enabled = true;
            }

            //if the current sprite name set for the south side is input then it cycles it to output and sets the
            //input/output image of the tile
            else if (ui_south_io.GetComponent<Image>().sprite.name == "input")
            {
                ui_south_io.GetComponent<Image>().sprite = outputIMG;
                tile_south_io.GetComponent<Image>().sprite = ui_south_io.GetComponent<Image>().sprite;
                tile_south_io.GetComponent<Image>().enabled = true;
            }

            //if the current sprite name set for the south side is output then it cycles it to noput and sets the
            //input/output image of the tile
            else if (ui_south_io.GetComponent<Image>().sprite.name == "output")
            {
                ui_south_io.GetComponent<Image>().sprite = noputIMG;
                tile_south_io.GetComponent<Image>().sprite = ui_south_io.GetComponent<Image>().sprite;
                tile_south_io.GetComponent<Image>().enabled = false;
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
        if (ui_east_io != null)
        {
            if (ui_east_io.GetComponent<Image>().sprite.name == "noput")
            {
                ui_east_io.GetComponent<Image>().sprite = inputIMG;
                tile_east_io.GetComponent<Image>().sprite = ui_east_io.GetComponent<Image>().sprite;
                tile_east_io.GetComponent<Image>().enabled = true;
            }

            else if (ui_east_io.GetComponent<Image>().sprite.name == "input")
            {
                ui_east_io.GetComponent<Image>().sprite = outputIMG;
                tile_east_io.GetComponent<Image>().sprite = ui_east_io.GetComponent<Image>().sprite;
                tile_east_io.GetComponent<Image>().enabled = true;
            }

            else if (ui_east_io.GetComponent<Image>().sprite.name == "output")
            {
                ui_east_io.GetComponent<Image>().sprite = noputIMG;
                tile_east_io.GetComponent<Image>().sprite = ui_east_io.GetComponent<Image>().sprite;
                tile_east_io.GetComponent<Image>().enabled = false;
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
        if (ui_west_io != null)
        {
            if (ui_west_io.GetComponent<Image>().sprite.name == "noput")
            {
                ui_west_io.GetComponent<Image>().sprite = inputIMG;
                tile_west_io.GetComponent<Image>().sprite = ui_west_io.GetComponent<Image>().sprite;
                tile_west_io.GetComponent<Image>().enabled = true;
            }

            else if (ui_west_io.GetComponent<Image>().sprite.name == "input")
            {
                ui_west_io.GetComponent<Image>().sprite = outputIMG;
                tile_west_io.GetComponent<Image>().sprite = ui_west_io.GetComponent<Image>().sprite;
                tile_west_io.GetComponent<Image>().enabled = true;
            }

            else if (ui_west_io.GetComponent<Image>().sprite.name == "output")
            {
                ui_west_io.GetComponent<Image>().sprite = noputIMG;
                tile_west_io.GetComponent<Image>().sprite = ui_west_io.GetComponent<Image>().sprite;
                tile_west_io.GetComponent<Image>().enabled = false;
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
}
