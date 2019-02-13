using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct signal
{
    public int element; //Type of element
    public int units; //The amount of element being passed through
    public int inout; //0 for input 1 for output

    public signal (int elem, int uni, int ino)
    {
        element = elem;
        units = uni;
        inout = ino;

    }
}

public class Tile : MonoBehaviour
{
    Tile mytile;
    //The Tile uses data from the signal struct in order to create the tile

    public signal signal_data;
    public Dictionary<string, signal> sides;


    public Tile(Dictionary<string, signal> side)
    {
       
        sides = side;
    }

    public Tile()
    { //Default constructor for the tile 
        signal_data = new signal(0, 0, 0);
        sides = new Dictionary<string, signal>
        {
            {"up",signal_data },
            { "down",signal_data },
            { "left",signal_data},
            { "right",signal_data},
        };

    }


    public void change_signal(signal new_signal, string side) //Changes the signal of the tile in that specific section 
    {
        sides["side"] = new_signal;
    }

    public void print_signal(signal p_signal)
    {
       Debug.Log("element: " + p_signal.element);
        Debug.Log("units: " + p_signal.units);
        Debug.Log("I/O: " + p_signal.inout);
    }

    public void print_tile() //Prints out the data in the tile by printing the dictionary
    {
        foreach (KeyValuePair<string, signal> elem in sides){
            Debug.Log("Side:" + elem.Key);
            print_signal(elem.Value);
        }
    }

    private void Start()
    {
    
        Tile mytile = new Tile();
        //print_tile();
        
   

    }
}
