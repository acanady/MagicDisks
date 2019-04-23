using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchTile : Tile
{
    public bool inversion;

    public switchTile(Dictionary<string, signal> side)
    {
        inversion = true;
        sides = side;
    }

    public switchTile()
    {
        inversion = true;
        signal_data = new signal(0, 0);
        sides = new Dictionary<string, signal>

        {
            {"up",signal_data },
            { "down",signal_data },
            { "left",signal_data},
            { "right",signal_data},
        };
    }


    signal f_switch(switchTile tile, string input, string check_output)
    {
        signal return_data = new signal(0, 1);
        //given a tile as well as the input and output the switch function will test to see
        //how information will be sent through the tile dependent on the input/output and whether or not
        //inversion is set to true.

        if (!tile.inversion)
        {
            Debug.Log("Inversion is set to false");
            if (tile.sides[check_output].units > 0 && tile.sides[check_output].inout == 'I')
            {
                //In this case there is some element passing through the check_output side so we allow the input to be passed through to the output
                return_data.inout = 1;
                return_data.units = tile.sides[input].units;
                return return_data; //returns the tile data to be assigned to the proper output of the tile in other script.
            }
            else
            {
                return return_data; //In this case the return_data returned is the default with the side in question outputting  nothing.
            }


        }
        else if (tile.inversion) //This else is for inversion. This code runs if the switch tile is in inversion mode.
        {
            Debug.Log("Tile is inverted");
            if (tile.sides[check_output].units == 0) //Checks to see if there is nothing going through the check output side, checking input and output of this side is unncecessary.
            {
                
                return_data.inout = 1;
                return_data.units = tile.sides[input].units;
                return return_data; //returns the tile data to be assigned to the proper output of the tile in other script
            }
            else
            {
                return return_data; //In this case the return_data returned is th e defualt with the side in question outputting nothing.
            }
        }
        return return_data;
    }

    public void print_switchTile()
    {
        print_tile();
        Debug.Log("inversion is: " + inversion);
    }
}
