using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class active_image : MonoBehaviour
{
    private bool isactive = false;
    public bool input = false;
    public bool output = false;

    public Sprite outputIMG;
    public Sprite inputIMG;
    public Sprite noputIMG;

    Image myimage;

    void Start()
    {
        myimage = GetComponent<Image>();
    }

    void Update()
    {
        if (output) //checks if the iamge sprite for this side is set to output if so it chagnes the sprite to be the purple color
        {
            myimage.sprite = outputIMG;
            isactive = true;
        }

        else if (input) //checks if the iamge sprite for this side is set to input if so it changes the sprite to be the orange color
        {
            myimage.sprite = inputIMG;
            isactive = true;
        }

        else // if nothing is set then the sprite itself is set to inactive
        {
            isactive = false;
            myimage.sprite = noputIMG;
        }

        myimage.enabled = isactive;
        

    }

}
