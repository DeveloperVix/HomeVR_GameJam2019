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
    public GameObject objToTake;

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

        if (Input.GetButtonDown("ButtonA_OnC"))//1
        {
            Debug.Log("presiono A");
            ShowButton("A");
        }

        if (Input.GetButtonDown("ButtonB_OnC"))//2
        {
            Debug.Log("presiono B");
            ShowButton("B");
        }

        if (Input.GetButtonDown("ButtonD_OnC"))//3
        {
            Debug.Log("presiono D");
            ShowButton("D");
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
            objToTake.GetComponent<StatusObj>().forceLaunch++;
            Debug.Log(objToTake.name);
            nextTime = Time.time + rateLaunch;
        }

        if (Input.GetButtonUp("ButtonC_OnC") || Input.GetKeyUp("g") && canTake)//5
        {
            Debug.Log("suelto C");
            ShowButton("C");
            objToTake.GetComponent<StatusObj>().currentStatus = StatusObj.Status.launch;
            nextTime = 0f;
            DropObj();
        }

        //Debug.Log(Input.GetAxis("Vertical"));
        //Debug.Log(Input.GetAxis("Horizontal"));

        txtAxis.text = "X: " + Input.GetAxis("Horizontal") + "   Y: " + Input.GetAxis("Vertical");
        #endregion

        axisY = Input.GetAxis("Vertical");
        transform.position = transform.position + theCamera.transform.forward * axisY * speedMove * Time.deltaTime;
        

        //Debug.Log(transform.eulerAngles);
    }

    void ShowButton(string theButton)
    {
        txtButton.text = "Presiono " + theButton;
    }

    void TakingObj()
    {
        objToTake.GetComponent<Rigidbody>().useGravity = false;
        objToTake.transform.SetParent(hand.transform);
        objToTake.transform.position = hand.transform.position;
    }
    void DropObj()
    {
        objToTake.transform.SetParent(null);
        objToTake.GetComponent<Rigidbody>().useGravity = true;
        objToTake = null;
        canTake = false;
    }
}
