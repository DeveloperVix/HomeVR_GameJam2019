using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElRegalo : MonoBehaviour, IActionEvent
{
    public bool executeAction
    {
        get;
        set;
    }

    public GameObject canvasGift;
    GameObject player;

    public List<string> dialog;
    public Text txtFeedback;
    public bool final = true;

    // Start is called before the first frame update
    void Start()
    {       
        player = GameObject.FindGameObjectWithTag("Player");
        final = true;
        executeAction = false;
    }

    public void Update()
    {
        Vector3 toFace = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
        canvasGift.transform.LookAt(toFace);
    }

    public void ActiveBehaviour()
    {
        canvasGift.gameObject.SetActive(true);
        txtFeedback.gameObject.SetActive(true);
        if(final)
        {
            txtFeedback.text = dialog[0];
        }
        else
        {
            txtFeedback.text = dialog[1];
        }
    }

    public void TakeGift()
    {
        executeAction = true;
        ControlPlayer.Instance.observedObject = gameObject;
    }

    public void NoTakeGift()
    {
        executeAction = false;
        ControlPlayer.Instance.observedObject = null;
    }
}
