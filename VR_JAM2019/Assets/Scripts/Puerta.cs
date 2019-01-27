using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour, IActionEvent
{
    public bool executeAction
    {
        get;
        set;
    }

    public void ActiveBehaviour()
    {
        Debug.Log("Ejecuta la animación");
    }

    // Start is called before the first frame update
    void Start()
    {
        executeAction = false;
        
    }

    public void CanOpen()
    {
        executeAction = true;
        ControlPlayer.Instance.observedObject = gameObject;
    }

    public void CanNotOpen()
    {
        executeAction = false;
        ControlPlayer.Instance.observedObject = null;
    }
}
