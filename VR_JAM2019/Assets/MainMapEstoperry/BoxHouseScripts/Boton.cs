using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour, IActionEvent
{

    public GameObject[] Props =  new GameObject[10];
    public GameObject AudioEntrada;

    public bool executeAction
    {
        get;
        set;
    }

    void Start()
    {
        executeAction = false;
    }

    public void ActiveBehaviour()
    {
        for (int i = 0; i < Props.Length; i++)
        {
            Props[i].SetActive(true);
        }
        gameObject.SetActive(false);
        AudioEntrada.SetActive(false);
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
