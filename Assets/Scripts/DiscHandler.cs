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

    public class Disc
    {

        public Tile[,] tiles = new Tile[5, 5]; //2d array for the tile class

        int ID;
        //Dict to hold all tiles based on a specific ID
        Dictionary<int, Tile> Tiles = new Dictionary<int, Tile>();

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

        void data_flow(Tile start) //Perhaps the most important function, it's what iterates through all connected tiles it needs only to be given a start tile
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
        }

        //Checks if the side oppossite to the parents side is set to input, if so it returns true
        bool check_opposite(Tile child_tile, string parent_side)
        {
            string ct_side = opposite_io(parent_side); //child tile oppossite side of parent_side

            if(child_tile.sides[ct_side].inout == 0) //If the oppossite end of the child tile from the parent tile is set to accept input
            {
                return true;
            }

            else
            {
                return false;
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
        Tile.tile_location child_location(Tile.tile_location parent_location, string side)
        {
            //given a side it returns the location of the child, if it does not exist. I.E out of bounds, it returns null
            Tile.tile_location child_loc = new Tile.tile_location(0, 0);
            int x = parent_location.i;
            int y = parent_location.j;
            switch (side)
            {
                case "north":
                    if (tiles[x - 1, y] != null) {
                        child_loc.i = x - 1;
                        child_loc.j = y;
                    }
                    else
                    {
                        print("attempting to access invalid tile space, no tile at " + (x - 1) + "," + y);
                    }
                    break;
                case "south":
                    if(tiles[x+1, y] != null)
                    {
                        child_loc.i = x + 1;
                        child_loc.j = y;
                    }
                    else
                    {
                        print("attempting to access invalid tile space, no tile at " + (x+1) + "," + y);
                    }
                    break;
                case "east":
                    if(tiles[x, y+1] != null)
                    {
                        child_loc.i = x;
                        child_loc.j = y + 1;
                    }
                    else
                    {
                        print("attempting to access invalid tile space, no tile at " + x + "," + (y+1));
                    }
                    break;
                case "west":
                    if(tiles[x,y-1] != null)
                    {
                        child_loc.i = x;
                        child_loc.j = y - 1;
                    }
                    else
                    {
                        print("attempting to access invalid tile space, no tile at " + x + "," + (y-1));
                    }
                    break;
                default:
                    break;
            }

            return child_loc;
        }

        // Float for making new IDs



        // All tiles and discs will have a single script on them that gives ID

        // Width/Height of Tiles, used for scaling the math
        //float TileSize;

        // Dict to hold all discs
        //Dictionary<int, Disc> Discs = new Dictionary<int, Disc>();


        // ----[Disc Class Goes Here]----



        /*
        // Call when 'compiling' the disc; dID = disc ID
        void UpdateDisc(int dID)
        {
            Disc disc = Discs[dID];
            // have each tile update what it's connected to
            for (int i = 0; i < disc.tiles.length; i++)
            {
                for (int j = 0; j < disc.tiles[i].length; j++)
                {
                    //Update the tile here

                }
            }
        }

        Vector2 GetTileIndex(GameObject tile, GameObject disc)
        {
            Vector3 pos = new Vector3(0f, 0f, 0f);
            pos = tile.GetComponent<Transform>().localPosition;

            float x = pos.x;
            int arX = 9;
            float z = pos.z;
            int arZ = 9;
            float scale = TileSize * 4.5f;

            // get x
            if (x < (scale / 9) && x > -(scale / 9))
            {
                arX = 4;
            }
            else if (x < 3*(scale / 9) && x > (scale / 9))
            {
                arX = 3;
            }
            else if (x < 5*(scale / 9) && x > 3*(scale / 9))
            {
                arX = 2;
            }
            else if (x < 7*(scale / 9) && x > 5*(scale / 9))
            {
                arX = 1;
            }
            else if (x < 9*(scale / 9) && x > 7*(scale / 9))
            {
                arX = 0;
            }
            else if (x < -(scale / 9) && x > -3*(scale / 9))
            {
                arX = 5;
            }
            else if (x < -3*(scale / 9) && x > -5*(scale / 9))
            {
                arX = 6;
            }
            else if (x < -5*(scale / 9) && x > -7*(scale / 9))
            {
                arX = 7;
            }
            else if (x < -7*(scale / 9) && x > -9*(scale / 9))
            {
                arX = 8;
            }
            else
            {
                arX = 100; //In this case something went wrong, this should never be 100
            }

            // get z
            if (z < (scale / 9) && z > -(scale / 9))
            {
                arZ = 4;
            }
            else if (z < 3 * (scale / 9) && z > (scale / 9))
            {
                arZ = 3;
            }
            else if (z < 5 * (scale / 9) && z > 3 * (scale / 9))
            {
                arZ = 2;
            }
            else if (z < 7 * (scale / 9) && z > 5 * (scale / 9))
            {
                arZ = 1;
            }
            else if (z < 9 * (scale / 9) && z > 7 * (scale / 9))
            {
                arZ = 0;
            }
            else if (z < -(scale / 9) && z > -3 * (scale / 9))
            {
                arZ = 5;
            }
            else if (z < -3 * (scale / 9) && z > -5 * (scale / 9))
            {
                arZ = 6;
            }
            else if (z < -5 * (scale / 9) && z > -7 * (scale / 9))
            {
                arZ = 7;
            }
            else if (z < -7 * (scale / 9) && z > -9 * (scale / 9))
            {
                arZ = 8;
            }
            else
            {
                arZ = 100; //this should never be true, if it is then something went wrong
            }

            Vector2 arPos = new Vector2(arX, arZ);
            return arPos;
        }

        Vector3 GetCellCenter(Vector2 index)
        {
            int x = Mathf.RoundToInt(index.x);
            int z = Mathf.RoundToInt(index.y);

            float h = 0f;
            float w = 0f;

            switch (x)
            {
                case 0:
                    h = 8 * (TileSize / 9);
                    break;
                case 1:
                    h = 6 * (TileSize / 9);
                    break;
                case 2:
                    h = 4 * (TileSize / 9);
                    break;
                case 3:
                    h = 2 * (TileSize / 9);
                    break;
                case 4:
                    h = 0f;
                    break;
                case 5:
                    h = -2 * (TileSize / 9);
                    break;
                case 6:
                    h = -4 * (TileSize / 9);
                    break;
                case 7:
                    h = -6 * (TileSize / 9);
                    break;
                case 8:
                    h = -8 * (TileSize / 9);
                    break;
            }

            switch (z)
            {
                case 0:
                    w = 8 * (TileSize / 9);
                    break;
                case 1:
                    w = 6 * (TileSize / 9);
                    break;
                case 2:
                    w = 4 * (TileSize / 9);
                    break;
                case 3:
                    w = 2 * (TileSize / 9);
                    break;
                case 4:
                    w = 0f;
                    break;
                case 5:
                    w = -2 * (TileSize / 9);
                    break;
                case 6:
                    w = -4 * (TileSize / 9);
                    break;
                case 7:
                    w = -6 * (TileSize / 9);
                    break;
                case 8:
                    w = -8 * (TileSize / 9);
                    break;
            }

            Vector3 dist = new Vector3(h, 0f, w);
            return dist;
        }

        // RemoveTile: Disconnects a Tile from the board, 
        //             Edits the disc array of tiles
        //             Attachs tile to controller
        public void RemoveTile(GameObject tile, GameObject disc, Transform conTrans)
        {
            int discID = disc.GetComponent<IDScript>().ID;
            int tileID = tile.GetComponent<IDScript>().ID;

            // Get array position of the tile
            Vector2 pos = GetTileIndex(tile, disc);
            // Use disc function to update the status of the pos in the array

            tile.GetComponent<Transform>().SetParent(conTrans);
            tile.GetComponent<Rigidbody>().isKinematic = true;
            tile.GetComponent<Rigidbody>().useGravity = false;
        }


        // PlaceTile: Checks the position of the tile relative to disc,
        //            Determines the corresponding grid position and location in array
        //            If position is empty, disconnect tile from con and place on disk
        //            Else do nothing, maybe flash outline red
       public void PlaceTile(GameObject tile, GameObject disc)
        {
            int discID = disc.GetComponent<IDScript>().ID;
            int tileID = tile.GetComponent<IDScript>().ID;

            // temporarily make the tile a child of the disc to get local pos
            tile.GetComponent<Transform>().SetParent(disc.transform);
            tile.GetComponent<Rigidbody>().isKinematic = true;
            tile.GetComponent<Rigidbody>().useGravity = false;

            Vector2 pos = GetTileIndex(tile, disc);
            int xpos = Mathf.RoundToInt(pos.x);
            int ypos = Mathf.RoundToInt(pos.y);

            Disc newDisc = new Disc();
            newDisc = Discs[discID];
            // Check if that cell is full
            // if it is, don't place the tile, break
            if (pos.x == 100 || pos.y == 100)
            {
                Debug.LogError("Invalid tile location, position returned values x = " + pos.x + " and y = "+ pos.y + " check GetTileIndex function in DiscHandler");
            }
            else if (newDisc.tiles[xpos, ypos] == null)
            {
                Debug.Log("Position is null, so a tile can be placed at x-position: " + xpos + " y-position: " + ypos);

                //The new disc is updated and then will be used to overwrite that ID in disc ID's
                newDisc.tiles[xpos, ypos] = Tiles[tileID];
                Discs[discID] = newDisc;
            }

            Vector3 dist = GetCellCenter(pos);

            tile.GetComponent<Transform>().localPosition = dist;
            tile.GetComponent<Transform>().rotation = disc.transform.rotation;

        }*/

        /*void makeDisc(int size)
        {
            Disc newDisc = new Disc();
            ID = Random.Range(00000, 99999);
            while (Discs.ContainsKey(ID))
            {
                ID = Random.Range(00000, 99999);
                Debug.Log("Getting new ID for Disc");
            }
            Discs[ID] = newDisc;
        }*/
    }
}

