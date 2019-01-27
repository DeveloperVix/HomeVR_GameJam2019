using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPlayer : MonoBehaviour
{
    public Text txtAxis;
    public Text txtButton;

 
    public float speedMove = 5f;

    GameObject theCamera;

    public GameObject hand;

    float axisY;

    public bool canTake = false;
    public GameObject observedObject;

    private static ControlPlayer instance;

    float rateLaunch = 0.5f;
    float nextTime;

    public static ControlPlayer Instance
    {
        get{   return instance;}
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        theCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        #region Joystick en @C
        /*Para la configuración del joystick en @ C
          * joystick button 0->C
          */

        if (Input.GetButtonDown("ButtonA_OnC") || Input.GetKeyDown("a") &&
            observedObject != null)//1
        {
            Debug.Log("presiono A");
            ShowButton("A");
            if(observedObject.GetComponent<IActionEvent>().executeAction)
            {
                observedObject.GetComponent<IActionEvent>().ActiveBehaviour();
            }         
        }

        if (Input.GetButtonDown("ButtonB_OnC"))//2
        {
            Debug.Log("presiono B");
            ShowButton("B");
        }

        if (Input.GetButtonDown("ButtonD_OnC") || Input.GetKeyDown("d"))//3
        {
            Debug.Log("presiono D");
            ShowButton("D");
            _GM.Instance.PauseGame();
        }

        if ((Input.GetButtonDown("ButtonRT_OnC")) || Input.GetKeyDown("f") && canTake)//4
        {
            Debug.Log("presiono RT");
            ShowButton("RT");

            TakingObj();

        }

        if (Input.GetButtonUp("ButtonRT_OnC") || Input.GetKeyUp("f") && canTake)
        {
            DropObj();
        }

        if (Input.GetButton("ButtonC_OnC") || Input.GetKey("g") && nextTime < Time.time && canTake)//5
        {
            Debug.Log("presiono C");
            ShowButton("C");
            observedObject.GetComponent<StatusObj>().forceLaunch++;
            Debug.Log(observedObject.name);
            nextTime = Time.time + rateLaunch;
        }

        if (Input.GetButtonUp("ButtonC_OnC") || Input.GetKeyUp("g") && canTake)//5
        {
            Debug.Log("suelto C");
            ShowButton("C");
            observedObject.GetComponent<StatusObj>().currentStatus = StatusObj.Status.launch;
            nextTime = 0f;
            DropObj();
        }

        //Debug.Log(Input.GetAxis("Vertical"));
        //Debug.Log(Input.GetAxis("Horizontal"));

        txtAxis.text = "X: " + Input.GetAxis("Horizontal") + "   Y: " + Input.GetAxis("Vertical");
        #endregion

        axisY = Input.GetAxis("Vertical");
        transform.position = transform.position + theCamera.transform.forward * axisY * speedMove * Time.deltaTime;
        
    }

    void ShowButton(string theButton)
    {
        txtButton.text = "Presiono " + theButton;
    }

    void TakingObj()
    {
        observedObject.GetComponent<Rigidbody>().useGravity = false;
        observedObject.transform.SetParent(hand.transform);
        observedObject.transform.position = hand.transform.position;
    }
    void DropObj()
    {
        observedObject.transform.SetParent(null);
        observedObject.GetComponent<Rigidbody>().useGravity = true;
        observedObject = null;
        canTake = false;
    }
}
