using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    string[] elems = new string[] { "neutral", "earth", "fire", "wind", "water" };

    public struct tile_data
    {
        public int element; //Type of element
        public int units; //The amount of element being passed through
        public char inout; //Capital I for input, Capitol O for output

        public tile_data(int elem, int uni, char ino)
        {
            element = elem;
            units = uni;
            inout = ino;

        }
    }

    

    public struct SwitchTile
    {
        public tile_data tdata;
        public bool inversion;
        //Initialize a dictionary for the switch tile that functions as a reference to all 4 sides of the tile
        //and the data coming from those sides. N is for the north side, S if for the south side, W is for the West Siyeede.
        //and E is for the east side.
        public IDictionary<char, tile_data> sides;
        public SwitchTile(tile_data tdat, bool inv, IDictionary<char, tile_data> dict)
        {
            tdata = tdat;
            inversion = inv;
            sides = dict;
        }
    }

    public struct IfTile
    {
        public tile_data tdata;
        
        //In total there are 6 different types. 0 - 5 Less than, greather than, less than or equal to, greather than or equal to, equal, and not equal respectively.
        public int type;
        

        //Initialize a dictionary for the switch tile that functions as a reference to all 4 sides of the tile
        //and the data coming from those sides. N is for the north side, S if for the south side, W is for the West Siyeede.
        //and E is for the east side.
        public IDictionary<char, tile_data> sides;

        public IfTile(tile_data tdat, int typ, IDictionary<char, tile_data> dict)
        {
            tdata = tdat;
            sides = dict;
            type = typ;
        }
    }


    tile_data f_switch(SwitchTile tile, char input, char check_output)
    {
        tile_data return_data = new tile_data(0,0,'O');
        //given a tile as well as the input and output the switch function will test to see
        //how information will be sent through the tile dependent on the input/output and whether or not
        //inversion is set to true.

        if (!tile.inversion)
        {
            Debug.Log("Inversion is set to false");
            if (tile.sides[check_output].units > 0 && tile.sides[check_output].inout == 'I')
            {
                //In this case there is some element passing through the check_output side so we allow the input to be passed through to the output
                return_data.element = tile.sides[input].element;
                return_data.inout = 'O';
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
                return_data.element = tile.sides[input].element;
                return_data.inout = 'O';
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
       
    tile_data ifthen(IfTile tile, char inputA, char inputB, char elem_input) //Input A is checked against input B. If the value is true then the element_input is sent through the output.
    {                                                                        //Currently only checks units. Maybe be changed to allow user input to check units, element type, or both.
        tile_data return_data = new tile_data(0,0,'O');

        switch (tile.type)
        {
            case 0: //in this case we have a less than
                if (tile.sides[inputA].units < tile.sides[inputB].units)
                {
                    return_data = new tile_data(tile.sides[elem_input].element, tile.sides[elem_input].units, 'O');
                    return return_data;
                }
                else
                {
                    Debug.Log("less than chosen: not capable of producing true statement");
                }
                break;

            case 1: //in this case we have greather than chosen
                if (tile.sides[inputA].units > tile.sides[inputB].units)
                {
                    return_data = new tile_data(tile.sides[elem_input].element, tile.sides[elem_input].units, 'O');
                    return return_data;
                }
                else
                {
                    Debug.Log("greater than chosen: data not capable of prducing true statement");
                }
                break;

            case 2: //in this case we have less than or equal to
                if (tile.sides[inputA].units <= tile.sides[inputB].units)
                {
                    return_data = new tile_data(tile.sides[elem_input].element, tile.sides[elem_input].units, 'O');
                    return return_data;
                }
                else
                {
                    Debug.Log("less than or equal to chosen: data not capable of producing true statement");
                }
                break;

            case 3: //In this case we have greater than or equal to
                if (tile.sides[inputA].units >= tile.sides[inputB].units)
                {
                    return_data = new tile_data(tile.sides[elem_input].element, tile.sides[elem_input].units,'O');
                    return return_data;
                }
                else
                {
                    Debug.Log("greather than or equal to chosen: data not capable of producing true statement");
                }
                break;

            case 4: //In this case we have equal to
                if (tile.sides[inputA].units == tile.sides[inputB].units)
                {
                    return_data = new tile_data(tile.sides[elem_input].element, tile.sides[elem_input].units, 'O');
                    return return_data;
                }
                else
                {
                    Debug.Log("equal to chosen: data not capable of producing true statement");
                }
                break;

            case 5: //In this case we have not equal to
                if (tile.sides[inputA].units != tile.sides[inputB].units)
                {
                    return_data = new tile_data(tile.sides[elem_input].element, tile.sides[elem_input].units, 'O');
                    return return_data;
                }
                else
                {
                    Debug.Log("not equal to chosen: data not capable of producing true statement");
                }
                break;

            default:
                Debug.Log("default, oof. Somethings awry if this gets printed");
                break;
        }

        return return_data; //returns the default tile data struct outputing the netural element at 0 units
    }

    void Start()
    {
        tile_data tdata = new tile_data(0, 0, 'O');
        tile_data Ndata = new tile_data(4, 3, 'O');
        tile_data Edata = new tile_data(1, 3, 'I');

        IDictionary<char, tile_data> sides = new Dictionary<char, tile_data>()
        {
            {'N', Ndata}, {'S', tdata}, {'W', tdata}, {'E', Edata}
        };

        SwitchTile mytile = new SwitchTile(tdata, false, sides);
        tile_data xdata = f_switch(mytile, 'N', 'E');

        mytile.sides['W'] = xdata;
        Debug.Log(xdata.element);

}

    
}