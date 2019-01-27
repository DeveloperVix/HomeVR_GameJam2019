using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour, IActionEvent
{

    public AudioClip[] Songs = new AudioClip[3];
    public AudioSource SongController;
    public int NSong = 0;

    public bool executeAction
    {
        get;
        set;
    }

    void Awake()
    {
        executeAction = false;
        SongController = GetComponent<AudioSource>();
        SongController.clip = Songs[NSong];
        SongController.Play();
    }

    void Update()
    {
        if (!SongController.isPlaying)
        {
            ActiveBehaviour();
        }
    }

    public void ActiveBehaviour()
    {
        NSong++;
        if (NSong == Songs.Length)
            NSong = 0;
        SongController.clip = Songs[NSong];
        SongController.Play();
    }

    public void Onview()
    {
        executeAction = true;
        ControlPlayer.Instance.observedObject = gameObject;
    }

    public void Noview()
    {
        executeAction = false;
        ControlPlayer.Instance.observedObject = null;
    }
}
