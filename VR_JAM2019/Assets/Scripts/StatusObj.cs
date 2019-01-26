using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusObj : MonoBehaviour
{
    public enum Status { Idle, Taking};
    public Status currentStatus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerTakeMe()
    {
        currentStatus = Status.Taking;
    }

    public void Idle()
    {
        currentStatus = Status.Idle;
    }
}
