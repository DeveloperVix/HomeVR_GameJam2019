using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestart : MonoBehaviour, IActionEvent
{
    public bool executeAction
    {
        get;
        set;
    }
    public void ActiveBehaviour()
    {
        SceneManager.LoadScene("Neighborhood");
    }

    public void ExecuteAction()
    {
        executeAction = true;
        ControlPlayer.Instance.observedObject = gameObject;
    }

    public void NoExecuteAction()
    {
        executeAction = false;
        ControlPlayer.Instance.observedObject = null;
    }
}
