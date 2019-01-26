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

    float axisY;

    // Start is called before the first frame update
    void Start()
    {
        theCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        #region Joystick en @C
        /*Para la configuración del joystick en @ C
          * joystick button 0->C
          */
        if (Input.GetButtonDown("ButtonC_OnC"))//0
        {
            Debug.Log("presiono C");
            //transform.Rotate(Vector3.left * spinValue * Time.deltaTime);
            ShowButton("C");
        }

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

        if (Input.GetButtonDown("ButtonRT_OnC"))//4
        {
            Debug.Log("presiono RT");
            ShowButton("RT");
        }

        if (Input.GetButtonDown("ButtonRB_OnC"))//5
        {
            Debug.Log("presiono RB");
            ShowButton("RB");
        }

        //Debug.Log(Input.GetAxis("Vertical"));
        //Debug.Log(Input.GetAxis("Horizontal"));

        txtAxis.text = "X: " + Input.GetAxis("Horizontal") + "   Y: " + Input.GetAxis("Vertical");
        #endregion

        axisY = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speedMove * axisY * Time.deltaTime);

        Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, theCamera.transform.localEulerAngles.y + 5f, transform.eulerAngles.z);

        transform.rotation = Quaternion.Euler(eulerRotation);
    }

    void ShowButton(string theButton)
    {
        txtButton.text = "Presiono " + theButton;
    }
}
