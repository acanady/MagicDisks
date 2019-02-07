﻿using System.Collections;
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
    // Dict to hold all discs
    Dictionary<float, Disc> Discs = new Dictionary<double, Disc>();

    // Float for making new IDs
    float ID;

    // ----[Disc Class Goes Here]----

    // Start is called before the first frame update
    void Start()
    {
        
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
    void UpdateDisc(float dID)
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
}
