using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ambience : MonoBehaviour
{
    public AudioClip music;
    public AudioSource music_source;

    // Start is called before the first frame update
    void Start()
    {
        music_source.clip = music;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!music_source.isPlaying)
        {
            music_source.Play();
        }
    }
}
