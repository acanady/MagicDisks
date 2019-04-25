using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour

    
{

    public AudioClip click;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source.clip = click;
    }

    // Update is called once per frame
    public void play_clip()
    {
        source.Play();
    }
}
