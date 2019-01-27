using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSleep : MonoBehaviour, IActionEvent
{

    public GameObject fadeIn;

    public Text txtFeedback;

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
        fadeIn.SetActive(true);
        txtFeedback.gameObject.SetActive(true);
        txtFeedback.text = "Sleeping";
    }

    public void GoToSleep()
    {
        executeAction = true;
        ControlPlayer.Instance.observedObject = gameObject;
    }

    public void NoSleep()
    {
        executeAction = false;
        ControlPlayer.Instance.observedObject = null;
    }
}
