using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public struct signal
    {
        public int units; //The amount of element being passed through
        public int inout; //0 for input 1 for output -1 for nothing

        public signal(int uni, int ino)
        {

            units = uni;
            inout = ino;

        }
    }

    public struct tile_location
    {
        public int i; //The i value for the array location, rows
        public int j; //the j value for the array location, columns

        public tile_location(int i_loc, int j_loc)
        {
            i = i_loc;
            j = j_loc;
        }
    }

     //The Tile uses data from the signal struct in order to create the tile

    public signal signal_data;
    public int ID;
    public Dictionary<string, signal> sides;
    public int iftype; // the if tile type of the tile if the tile is an if tile
    public string tile_type; // the string type of the tile
    public tile_location tile_loc;//the array location value of the tile

    //There are 3 types of tiles, if tiles, sitch tiles, and flow tiles
    string[] tile_types = new string[] { "if", "switch", "flow" };

    public Tile(Dictionary<string, signal> side, int if_type, string tiletype, tile_location tile_loca)
    {
        //poorly written code but allows me to initalize a tile with all the necessary bits and bobs
        sides = side;
        iftype = if_type;
        tile_type = tiletype;
        tile_loc = tile_loca;
    }

    public Tile()
    { //Default constructor for the tile 
        signal_data = new signal(0, -1);
        sides = new Dictionary<string, signal>
        {
            {"north",signal_data},
            { "south",signal_data},
            { "west",signal_data},
            { "east",signal_data},
        };

        iftype = 0; //iftile type 0 is a less than tile
        tile_type = tile_types[0]; //tile type of 0 is an if tile
        tile_loc = new tile_location(0, 0);//default location of tile is 0,0

    }


    public void change_signal(signal new_signal, string side) //Changes the signal of the tile in that specific section 
    {
        sides[side] = new_signal;
    }



    public void print_signal(signal p_signal, int num)
    {

        print(" tile num " + num + " units: " + p_signal.units);
        print("tile num " + num + " I/O: " + p_signal.inout);
    }

    public signal ifthen(Tile tile, string inputA, string inputB, string data_flow) //Input A is checked against input B. If the value is true then the data flow is sent through the output.
    {                                                                        //Currently only checks units. Maybe be changed to allow user input to check units, element type, or both. //elem_input isn't
                                                                             //named that well, but it's the side of the tile that the signal we wish to pass through is coming
        signal return_data = new signal(0, 0);

        switch (tile.iftype)
        {
            case 0: //in this case we have a less than
                if (tile.sides[inputA].units < tile.sides[inputB].units)
                {
                    return_data = new signal(1, 1);
                    print("less than chosen: statement is true!");
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
                    return_data = new signal(1, 1);
                    print("greather than chosen: statement is true!");
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
                    //sets signal streingth to 1 and sends it through return data
                    return_data = new signal(1, 1);
                    print("less than or equal to chosen: statement is true!");
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
                    return_data = new signal(1, 1);
                    print("greather than or equal to chosen: statement is true!");
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
                    return_data = new signal(1, 1);
                    print("equal to chosen: statement is true");
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
                    return_data = new signal(1, 1);
                    print("not equal to chosen: statement is true!");
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

    public void print_tile(int num) //Prints out the data in the tile by printing the dictionary
    {
        foreach (KeyValuePair<string, signal> flow in sides)
        {
            //if the key does indeed exist it prints it
            if (flow.Key != null)
            {
                print("tile num " + num + " Side:" + flow.Key);
                print_signal(flow.Value, num);
            }
            else print("tile side: " + flow.Key + " not properly setup");
        }
    }

    public void print_iftile()
    {
       // print_tile(num);
        //Debug.Log("type: " + types[type]); //references the array of types to pring out the work for the type of tile it is
    }
}
