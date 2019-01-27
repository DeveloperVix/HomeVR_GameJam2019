using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GM : MonoBehaviour
{
    private static _GM instance;
    public static _GM Instance
    {
        get
        {
            return instance;
        }
    }


    public GameObject pauseUI;

    bool isPaused = false;

    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void PauseGame()
    {
        if(!isPaused)
        {
            Time.timeScale = 0f;
            isPaused = true;
            pauseUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            isPaused = false;
            pauseUI.SetActive(false);
        }
    }
}
