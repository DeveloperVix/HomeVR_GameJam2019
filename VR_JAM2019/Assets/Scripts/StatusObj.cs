using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusObj : MonoBehaviour
{

    public float forceLaunch = 0f;
    public float limitForce = 5f;

    Rigidbody rbd3D;

    public enum Status { Idle, launch};
    public Status currentStatus; 

    // Start is called before the first frame update
    void Start()
    {
        rbd3D = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(forceLaunch > limitForce)
        {
            forceLaunch = limitForce;
        }
    }
    private void FixedUpdate()
    {
        if(currentStatus == Status.launch)
        {
            rbd3D.AddForce(Vector3.forward * forceLaunch, ForceMode.Impulse);
        }

        if(rbd3D.velocity.y <= 0f && currentStatus != Status.Idle)
        {
            forceLaunch = 0f;
            currentStatus = Status.Idle;
        }
    }

    public void PlayerSeeMe()
    {
        ControlPlayer.Instance.canTake = true;
        ControlPlayer.Instance.observedObject = gameObject;
        Debug.Log("El jugador me ve");
    }

    public void PlayerNoSeeMe()
    {
        ControlPlayer.Instance.canTake = false;
        ControlPlayer.Instance.observedObject = null;
        Debug.Log("El jugador no me ve");
    }


}
