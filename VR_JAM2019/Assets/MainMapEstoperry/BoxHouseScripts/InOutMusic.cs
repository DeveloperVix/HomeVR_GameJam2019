using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOutMusic : MonoBehaviour
{
    public AudioClip[] Songs = new AudioClip[3];
    public AudioSource SongController;
    public int NSong = 0;
    public int In;
    public bool Inside = false;

    void  Start()
    {
        SongController = GetComponent<AudioSource>();
        SongController.clip = Songs[NSong];
        SongController.Play();
        In = 0;
    }

    void Update()
    {
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

    private void OnTriggerEnter(Collider Music)
    {

        if (Music.CompareTag("MainCamera"))
        {
            Debug.Log("Entro");
            if (Inside == false)
            {
                SongController.Pause();
                In++;
                Inside = true;
            }

            if (Inside == true)
            {
                SongController.UnPause();
                Inside = false;
            }
        }
    }
}
