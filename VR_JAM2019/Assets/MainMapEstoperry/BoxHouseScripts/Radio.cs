using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{

    public AudioClip[] Songs = new AudioClip[3];
    public AudioSource SongController;
    public int NSong = 0;

    public bool Control = false;

    void Awake()
    {
        SongController = GetComponent<AudioSource>();
        SongController.clip = Songs[NSong];
        SongController.Play();
    }

    void Update()
    {
        if (Control == true)
        {
            ChangeSong();
        }
        if (!SongController.isPlaying)
        {
            ChangeSong();
        }
    }

    public void ChangeSong()
    {
        NSong++;
        if (NSong == Songs.Length)
            NSong = 0;
        SongController.clip = Songs[NSong];
        SongController.Play();
    }
}
