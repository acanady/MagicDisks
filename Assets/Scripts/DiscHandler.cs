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
    public struct signal
    {
        public int element; //Type of element
        public int units; //The amount of element being passed through
        public int inout; //0 for input 1 for output

        public signal(int elem, int uni, int ino)
        {
            element = elem;
            units = uni;
            inout = ino;

        }
    }

    public class Tile
    {

        //The Tile uses data from the signal struct in order to create the tile

        public signal signal_data;
        public int ID;
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
            foreach (KeyValuePair<string, signal> elem in sides)
            {
                Debug.Log("Side:" + elem.Key);
                print_signal(elem.Value);
            }
        }
        //Creates a Tile type from the Tile class
        public Tile mytile = new Tile();
    }



    // All tiles and discs will have a single script on them that gives ID

    // Width/Height of Tiles, used for scaling the math
    float TileSize;

    // Dict to hold all discs
    Dictionary<int, Disc> Discs = new Dictionary<int, Disc>();

    //Dict to hold all tiles based on a specific ID
    Dictionary<int, Tile> Tiles = new Dictionary<int, Tile>();

    // Float for making new IDs
    int ID;

    // ----[Disc Class Goes Here]----

    // Start is called before the first frame update
    void Start()
    {
        TileSize = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void makeDisc(int size)
    {
        Disc newDisc = new Disc(size);
        ID = Random.Range(00000, 99999);
        while (Discs.ContainsKey(ID))
        {
            ID = Random.Range(00000, 99999);
            Debug.Log("Getting new ID for Disc");
        }
        Discs[ID] = newDisc;
    }

    void makeTile()
    {
        Tile newTile = new Tile();
        ID = Random.Range(0, 100);
        while (Tiles.ContainsKey(ID))
        {
            ID = Random.Range(0, 100);
            Debug.Log("Getting new ID for tile");
        }
        newTile.ID = ID;
        Tiles[ID] = newTile;
    }

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
    void RemoveTile(GameObject tile, GameObject disc, Transform conTrans)
    {
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
    void PlaceTile(GameObject tile, GameObject disc)
    {
        // temporarily make the tile a child of the disc to get local pos
        tile.GetComponent<Transform>().SetParent(disc.transform);
        tile.GetComponent<Rigidbody>().isKinematic = true;
        tile.GetComponent<Rigidbody>().useGravity = false;

        Vector2 pos = GetTileIndex(tile, disc);

        // Check if that cell is full
        // if it is, don't place the tile, break

        Vector3 dist = GetCellCenter(pos);

        tile.GetComponent<Transform>().localPosition = dist;
        tile.GetComponent<Transform>().rotation = disc.transform.rotation;
    }


}

    public class Disc
    {
        public int ID;

    }

    // Dict to hold all discs based on a specific ID

    

    public class Tile
    {
        public struct signal
        {
            public int element; //Type of element
            public int units; //The amount of element being passed through
            public int inout; //0 for input 1 for output

            public signal(int elem, int uni, int ino)
            {
                element = elem;
                units = uni;
                inout = ino;

            }
        }

        //The Tile uses data from the signal struct in order to create the tile

        public signal signal_data;
        public int ID;
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
            foreach (KeyValuePair<string, signal> elem in sides)
            {
                Debug.Log("Side:" + elem.Key);
                print_signal(elem.Value);
            }
        }
        //Creates a Tile type from the Tile class
        public Tile mytile = new Tile();
    }
    //End of Tile Class


    // All tiles and discs will have a single script on them that gives ID

    // Width/Height of Tiles, used for scaling the math