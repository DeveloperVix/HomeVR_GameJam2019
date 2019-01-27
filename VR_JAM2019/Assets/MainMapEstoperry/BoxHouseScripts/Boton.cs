using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{

    public GameObject[] Props =  new GameObject[10];

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SpawnProps()
    {
        for (int i = 0; i < Props.Length; i++)
        {
            Props[i].SetActive(true);
        }
        gameObject.SetActive(false);

    }
}
