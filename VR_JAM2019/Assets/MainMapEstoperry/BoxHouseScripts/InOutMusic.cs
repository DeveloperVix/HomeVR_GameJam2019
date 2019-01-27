using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOutMusic : MonoBehaviour
{
    public AudioClip[] Songs = new AudioClip[3];
    public AudioSource SongController;
    public GameObject Boton;
    public int NSong = 0;
    public int In;
    public bool Inside;

    void  Start()
    {
        SongController = GetComponent<AudioSource>();
        SongController.clip = Songs[NSong];
        SongController.Play();
        In = 0;
        Inside = false;
    }

    void Update()
    {
        if (In == 3)
        {
            Boton.SetActive(true);
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

        if (Music.CompareTag("Player"))
        {
            //SongController.Pause();

            if (In == 0 || In%2 != 0)
            {
               Debug.Log("Entro");
                SongController.UnPause();
                
            }

            if (In%2 == 0)
            {
                Debug.Log("Salio");
                SongController.Pause();
            }

            In++;
        }
    }
}
