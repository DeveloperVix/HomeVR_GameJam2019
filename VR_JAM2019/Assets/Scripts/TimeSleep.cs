using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSleep : MonoBehaviour, IActionEvent
{

    public GameObject fadeIn;

    public Text txtFeedback;

    public Text txtButtonWakeUp;

    public bool wakeUp = false;

    public GameObject wakeUpPosition;
    GameObject player;

    public bool executeAction
    {
        get;
        set;
    }

    void Start()
    {
        executeAction = false;
        wakeUp = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }
 
    public void ActiveBehaviour()
    {
        fadeIn.SetActive(true);
        txtFeedback.gameObject.SetActive(true);
        txtFeedback.text = "Sleeping";
        StartCoroutine(ActiveWakeUp());
    }

    IEnumerator ActiveWakeUp()
    {
        yield return new WaitForSeconds(5f);
        txtButtonWakeUp.gameObject.SetActive(true);
        wakeUp = true;
    }

    public void SetWakeUp()
    {
        player.transform.position = wakeUpPosition.transform.position;
        txtButtonWakeUp.gameObject.SetActive(false);
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
