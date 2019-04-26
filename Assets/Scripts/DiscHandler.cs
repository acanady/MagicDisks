using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This script handles all present discs.
 * It contains a dictionary of disc class instances.
 * Discs contain an array of contained tiles,
 * the disk input sources, the disc output connections,
 * and a linked list of all the tile connections
 * on the disc. */
public class DiscHandler : MonoBehaviour
{

    public GameObject vrcontroller;
    public bool cycle = true;
    public GameObject discGUI; //The GUI for the discs so that the disc handler can properly hand the tiles
    public GameObject passedGUI; //The all green GUI that shows when the puzzle has been solved
    public Tile[,] tiles;
    public Tile.signal signal_data;
    public Dictionary<string, Tile.signal> sides;
    public AudioClip hurrah;
    public AudioSource hurrah_source;

    int ID;
    //Dict to hold all tiles based on a specific ID
    Dictionary<int, Tile> Tiles;

    SteamVR_TrackedController controller;

    void Start()
    {
        controller = vrcontroller.GetComponent<SteamVR_TrackedController>();
        Tiles = new Dictionary<int, Tile>();
        tiles = new Tile[5, 5]; //2d array for the tile class

        signal_data = new Tile.signal(0, -1);
        sides = new Dictionary<string, Tile.signal>
        {
            {"north",signal_data},
            { "south",signal_data},
            { "west",signal_data},
            { "east",signal_data},
        };

        hurrah_source.clip = hurrah;
    }

    void Update()
    {
        if (controller.gripped)
        {
            //print("i have been gripped");
            demo_data_flow();
        }

    }

    void makeTile()
        //makes a default tile, the north south east and west sides are empty
        //sets a random tile ID from 0 to 1000 and puts it into the tile dictionary with that ID;
        //When a tile is removed this ID must be removed from the Dictionary
        {
            Tile newTile = new Tile();
            ID = Random.Range(0, 100);
            while (Tiles.ContainsKey(ID))
            {
                ID = Random.Range(0, 1000);
                Debug.Log("Getting new ID for tile");
            }
            newTile.ID = ID;
            Tiles[ID] = newTile;

            //Originally multiple discs were planned, this is no longer pheasible so discs require no ID

        }

    /* void data_flow(Tile start) //Perhaps the most important function, it's what iterates through all connected tiles it needs only to be given a start tile
     {

         //it flows the data of the tile given to whatever tiles are the output tiles
         //if the north side is set to output
         if (start.sides["north"].inout == 1)
         {
             //if the child tile that is opposite to the output is inputing, then push that data through
             if(check_opposite(tiles[child_location(start.tile_loc,"north").i, child_location(start.tile_loc, "north").j], "north"))
             {
                 //check to see if the tile being pushed to is a flow tile, if so we just overwrite the signal data on all sides that aren't the one input side
             }

         }
     }*/

    void demo_data_flow()
    {

        if (cycle)
        {
            //initializes the disc with the appropriate tiles, in face it will do this constanlty on void_update

            demo_disc_initialize();

            //Code for flow tile in locaiton 11
            Tile tile11 = tiles[2, 1];
            Tile tile12 = tiles[2, 2];
            Tile tile13 = tiles[2, 3];
            Tile tile17 = tiles[3, 2];


            if (tile11.sides["east"].inout == 1)
            {
                //checks to see if the tile12 is accepting relative to tile 11's east side
                if (check_opposite(tile12, "east"))
                {

                    //creates a new signal for tile 12 whose units from the east are the units pased in by the flow tile
                    Tile.signal signal_change = new Tile.signal(tile11.sides["east"].units, tile12.sides["west"].inout);
                    print("changing tile 12's units on the west side to be " + signal_change.units);
                    tile12.sides["west"] = signal_change;
                }
            }

            if (tile13.sides["west"].inout == 1)
            {
                if (check_opposite(tile12, "west"))
                {

                    Tile.signal signal_change = new Tile.signal(tile13.sides["west"].units, tile12.sides["east"].inout);
                    print("changing tile 12's units on the east side to be " + signal_change.units);
                    tile12.sides["east"] = signal_change;
                }
            }

            Tile.signal if_signal = tile12.ifthen(tile12, "west", "east", "north");
            //so if the tile at tile 12 is outputting
            if (tile12.sides["south"].inout == 1)
            {
                //If the signal relative to the south tile on tile 17 is accepting
                if (check_opposite(tile17, "south"))
                {
                    //sets tile 17's output to 1 Recall that tile 17's output cannot be changed in any other way
                    Tile.signal signal_change = new Tile.signal(if_signal.units, tile17.sides["north"].inout);
                    tile17.sides["north"] = signal_change;
                }
            }

            tile17.print_tile(17);
            if (tile17.sides["north"].units == 1)
            {
                print("tile 17 has properly recieved data puzzle solved!");
                cycle = false;
                discGUI.SetActive(false);
                passedGUI.SetActive(true);
                hurrah_source.Play();
            }

        }


    }

        //Checks if the side oppossite to the parents side is set to input, if so it returns true
        bool check_opposite(Tile child_tile, string parent_side)
        {
            string ct_side = opposite_io(parent_side); //child tile oppossite side of parent_side

            if (child_tile.sides[ct_side].inout == 0) //If the oppossite end of the child tile from the parent tile is set to accept input
            {
                return true;
            }

            else
            {
                return false;
            }
        }

    //ideally it initalizes the entire disc setting each tile to the proper values based on the tile_interact script. However, for this demo, it only does this for 4 tiles
    void demo_disc_initialize()
        {
        Tile.tile_location location;
        Dictionary<string, Tile.signal> sides;
        int iftype;
        string tile_type;

        for (int i = 11; i < 18; i++)
        {
            if (i == 11 || i == 12 || i == 13 || i == 17)
            {
                //since this is a demo it will only populate the board with tiles at locations 11, 12, 13, and 17
                location = discGUI.transform.GetChild(i).GetComponent<tile_interact>().location;
                print("tile location for tile " + i + " i: " + location.i + " tile location j: " + location.j);

                sides = discGUI.transform.GetChild(i).GetComponent<tile_interact>().sides;
                iftype = discGUI.transform.GetChild(i).GetComponent<tile_interact>().tile_if_type;
                tile_type = discGUI.transform.GetChild(i).GetComponent<tile_interact>().tile_type;

                Tile my_tile = new Tile(sides, iftype, tile_type, location);
                //print("tile " + i + " input output");
                //my_tile.print_tile(i);

                //sets the board at that location to that particular tile
                tiles[location.i, location.j] = my_tile;
            }

        }
    }

        //returns the oppossite side given the name of the side.
        string opposite_io(string side)
        {
            string opposite_side = null;

            switch (side)
            {
                case "north":
                    opposite_side = "south";
                    break;
                case "south":
                    opposite_side = "north";
                    break;
                case "east":
                    opposite_side = "west";
                    break;
                case "west":
                    opposite_side = "east";
                    break;
                default:
                    opposite_side = "oh_no";
                    break;
            }

            return opposite_side;
        }

        //returns the location of the child tile
        Tile child_tile_find(Tile.tile_location parent_location, string side)
        {
            //given a side it returns the location of the child, if it does not exist. I.E out of bounds, it returns null
            Tile.tile_location child_loc = new Tile.tile_location(0, 0);
            Tile child_tile = null;
            int x = parent_location.i;
            int y = parent_location.j;
            switch (side)
            {
                case "north":
                    if (tiles[x - 1, y] != null)
                    {
                        child_loc.i = x - 1;
                        child_loc.j = y;
                        child_tile = tiles[child_loc.i, child_loc.j];
                    }
                    else
                    {
                        print("attempting to access invalid tile space, no tile at " + (x - 1) + "," + y);
                    }
                    break;
                case "south":
                    if (tiles[x + 1, y] != null)
                    {
                        child_loc.i = x + 1;
                        child_loc.j = y;
                        child_tile = tiles[child_loc.i, child_loc.j];
                    }
                    else
                    {
                        print("attempting to access invalid tile space, no tile at " + (x + 1) + "," + y);
                    }
                    break;
                case "east":
                    if (tiles[x, y + 1] != null)
                    {
                        child_loc.i = x;
                        child_loc.j = y + 1;
                        child_tile = tiles[child_loc.i, child_loc.j];
                    }
                    else
                    {
                        print("attempting to access invalid tile space, no tile at " + x + "," + (y + 1));
                    }
                    break;
                case "west":
                    if (tiles[x, y - 1] != null)
                    {
                        child_loc.i = x;
                        child_loc.j = y - 1;
                        child_tile = tiles[child_loc.i, child_loc.j];
                    }
                    else
                    {
                        print("attempting to access invalid tile space, no tile at " + x + "," + (y - 1));
                    }
                    break;
                default:
                    break;
            }

            return child_tile;
        }
 }


