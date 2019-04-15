using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tile_interact : MonoBehaviour
{
    public GameObject UI;
    private bool open = false;
    public GameObject tile_east_io;
    public GameObject tile_west_io;
    public GameObject tile_south_io;
    public GameObject tile_north_io;
    private GameObject ui_north_io;
    private GameObject ui_south_io;
    private GameObject ui_east_io;
    private GameObject ui_west_io;

    public Sprite noputIMG;
    public Sprite inputIMG;
    public Sprite outputIMG;

    public void openUI()
    {
        if (!open)
        {
            UI.SetActive(true);
            open = true;
        }
        else
        {
            UI.SetActive(false);
            open = false;
        }
        
    }

   public void setInputOutput()
    {

        if (open)
        {
            ui_north_io = UI.transform.GetChild(0).gameObject;
            ui_south_io = UI.transform.GetChild(1).gameObject;
            ui_east_io = UI.transform.GetChild(2).gameObject;
            ui_west_io = UI.transform.GetChild(3).gameObject;

            //Takes the current sprite tile io color and sets it to the N,S,E,W UI
            ui_north_io.GetComponent<Image>().sprite = tile_north_io.GetComponent<Image>().sprite;
            ui_south_io.GetComponent<Image>().sprite = tile_south_io.GetComponent<Image>().sprite;
            ui_east_io.GetComponent<Image>().sprite = tile_east_io.GetComponent<Image>().sprite;
            ui_west_io.GetComponent<Image>().sprite = tile_west_io.GetComponent<Image>().sprite;
        }
    }

    public void setNorthIO()
    {
        if (ui_north_io != null)
        {
            if(ui_north_io.GetComponent<Image>().sprite.name == "noput")
            {
                ui_north_io.GetComponent<Image>().sprite = inputIMG;
                tile_north_io.GetComponent<Image>().sprite = ui_north_io.GetComponent<Image>().sprite;
                tile_north_io.GetComponent<Image>().enabled = true;
            }

            else if (ui_north_io.GetComponent<Image>().sprite.name == "input")
            {
                ui_north_io.GetComponent<Image>().sprite = outputIMG;
                tile_north_io.GetComponent<Image>().sprite = ui_north_io.GetComponent<Image>().sprite;
                tile_north_io.GetComponent<Image>().enabled = true;
            }

            else if (ui_north_io.GetComponent<Image>().sprite.name == "output")
            {
                ui_north_io.GetComponent<Image>().sprite = noputIMG;
                tile_north_io.GetComponent<Image>().sprite = ui_north_io.GetComponent<Image>().sprite;
                tile_north_io.GetComponent<Image>().enabled = false;
            }
            else
            {
                print(ui_north_io.GetComponent<Image>().sprite.name);
            }
        }

        else
        {
            print("TILE IS NULL");
        }
    }

    public void setSouthIO()
    {
        if (ui_south_io != null)
        {
            //if the current sprite name set for the south side is noput then it cycles it to input and sets the
            //input/output image of the tile
            if (ui_south_io.GetComponent<Image>().sprite.name == "noput")
            {
                ui_south_io.GetComponent<Image>().sprite = inputIMG;
                tile_south_io.GetComponent<Image>().sprite = ui_south_io.GetComponent<Image>().sprite;
                tile_south_io.GetComponent<Image>().enabled = true;
            }

            //if the current sprite name set for the south side is input then it cycles it to output and sets the
            //input/output image of the tile
            else if (ui_south_io.GetComponent<Image>().sprite.name == "input")
            {
                ui_south_io.GetComponent<Image>().sprite = outputIMG;
                tile_south_io.GetComponent<Image>().sprite = ui_south_io.GetComponent<Image>().sprite;
                tile_south_io.GetComponent<Image>().enabled = true;
            }

            //if the current sprite name set for the south side is output then it cycles it to noput and sets the
            //input/output image of the tile
            else if (ui_south_io.GetComponent<Image>().sprite.name == "output")
            {
                ui_south_io.GetComponent<Image>().sprite = noputIMG;
                tile_south_io.GetComponent<Image>().sprite = ui_south_io.GetComponent<Image>().sprite;
                tile_south_io.GetComponent<Image>().enabled = false;
            }

            //error detection
            else
            {
                print("Error at" + ui_south_io.GetComponent<Image>().sprite.name);
            }
        }

        //error detection
        else
        {
            print("TILE IS NULL");
        }

    }

    public void setEastIO()
    {
        if (ui_east_io != null)
        {
            if (ui_east_io.GetComponent<Image>().sprite.name == "noput")
            {
                ui_east_io.GetComponent<Image>().sprite = inputIMG;
                tile_east_io.GetComponent<Image>().sprite = ui_east_io.GetComponent<Image>().sprite;
                tile_east_io.GetComponent<Image>().enabled = true;
            }

            else if (ui_east_io.GetComponent<Image>().sprite.name == "input")
            {
                ui_east_io.GetComponent<Image>().sprite = outputIMG;
                tile_east_io.GetComponent<Image>().sprite = ui_east_io.GetComponent<Image>().sprite;
                tile_east_io.GetComponent<Image>().enabled = true;
            }

            else if (ui_east_io.GetComponent<Image>().sprite.name == "output")
            {
                ui_east_io.GetComponent<Image>().sprite = noputIMG;
                tile_east_io.GetComponent<Image>().sprite = ui_east_io.GetComponent<Image>().sprite;
                tile_east_io.GetComponent<Image>().enabled = false;
            }
            else
            {
                print(ui_east_io.GetComponent<Image>().sprite.name);
            }
        }

        else
        {
            print("TILE IS NULL");
        }
    }

    public void setWestIO()
    {
        if (ui_west_io != null)
        {
            if (ui_west_io.GetComponent<Image>().sprite.name == "noput")
            {
                ui_west_io.GetComponent<Image>().sprite = inputIMG;
                tile_west_io.GetComponent<Image>().sprite = ui_west_io.GetComponent<Image>().sprite;
                tile_west_io.GetComponent<Image>().enabled = true;
            }

            else if (ui_west_io.GetComponent<Image>().sprite.name == "input")
            {
                ui_west_io.GetComponent<Image>().sprite = outputIMG;
                tile_west_io.GetComponent<Image>().sprite = ui_west_io.GetComponent<Image>().sprite;
                tile_west_io.GetComponent<Image>().enabled = true;
            }

            else if (ui_west_io.GetComponent<Image>().sprite.name == "output")
            {
                ui_west_io.GetComponent<Image>().sprite = noputIMG;
                tile_west_io.GetComponent<Image>().sprite = ui_west_io.GetComponent<Image>().sprite;
                tile_west_io.GetComponent<Image>().enabled = false;
            }
            else
            {
                print(ui_west_io.GetComponent<Image>().sprite.name);
            }
        }

        else
        {
            print("TILE IS NULL");
        }
    }
}
