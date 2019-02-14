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

    // All tiles and discs will have a single script on them that gives ID

    // Width/Height of Tiles, used for scaling the math
    float TileSize;

    // Dict to hold all discs
    Dictionary<int, Disc> Discs = new Dictionary<int, Disc>();

    // Float for making new IDs
    float ID;

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

    void MakeDisc(int size)
    {
        Disc newDisc = new Disc(size);
        ID = Random.Range(00000, 99999);
        while (Discs.ContainsKey(ID))
        {
            ID = Random.Range(00000, 99999);
        }
        Discs[ID] = newDisc;
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

    Vector3 GetCellCenter(Vector2 index, Transform discTrans)
    {
        int x = Mathf.RoundToInt(index.x);
        int z = Mathf.RoundToInt(index.y);


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
        Vector2 pos = GetTileIndex(tile, disc);

    }


}
