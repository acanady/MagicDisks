using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifTile : Tile
{
    public int type;
    private string[] types = new string[] { "less than", "greater than", "less than or equal", "greater than or equal", "equal", "not equal" };

    public ifTile(Dictionary<string, signal> side)
    {

        sides = side;
    }

    public ifTile()
    { //Default constructor for the tile 
        type = 0; 
        signal_data = new signal(0, 0, 0);
        sides = new Dictionary<string, signal>

        {
            {"up",signal_data },
            { "down",signal_data },
            { "left",signal_data},
            { "right",signal_data},
        };

    }

  
    public signal ifthen(ifTile tile, string inputA, string inputB, string elem_input) //Input A is checked against input B. If the value is true then the element_input is sent through the output.
    {                                                                        //Currently only checks units. Maybe be changed to allow user input to check units, element type, or both. //elem_input isn't
                                                                             //named that well, but it's the side of the tile that the signal we wish to pass through is coming
        signal return_data = new signal(0, 0, 0);

        switch (tile.type)
        {
            case 0: //in this case we have a less than
                if (tile.sides[inputA].units < tile.sides[inputB].units)
                {
                    return_data = new signal(tile.sides[elem_input].element, tile.sides[elem_input].units, 1);
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
                    return_data = new signal(tile.sides[elem_input].element, tile.sides[elem_input].units, 1);
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
                    return_data = new signal(tile.sides[elem_input].element, tile.sides[elem_input].units, 1);
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
                    return_data = new signal(tile.sides[elem_input].element, tile.sides[elem_input].units, 1);
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
                    return_data = new signal(tile.sides[elem_input].element, tile.sides[elem_input].units, 'O');
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
                    return_data = new signal(tile.sides[elem_input].element, tile.sides[elem_input].units, 'O');
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

    public void print_iftile()
    {
        print_tile();
        Debug.Log("type: " + types[type]); //references the array of types to pring out the work for the type of tile it is
    }

    public void Start()
    {
        ifTile mytile = new ifTile();
        print_iftile();

    }

}
