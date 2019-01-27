using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DudeDialog : MonoBehaviour
{

    public List<string> theDialogs;
    public Text txtDialog;
    int indexDialog = 0;
    bool executeDialog = false;

    public GameObject canvasDude;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        canvasDude.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toFace = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
        canvasDude.transform.LookAt(toFace);
    }

    IEnumerator ShowDialogs()
    {
        while(executeDialog)
        {
            
            txtDialog.text = theDialogs[indexDialog];
            yield return new WaitForSeconds(5f);
            indexDialog++;
            if (indexDialog == theDialogs.Count)
            {
                executeDialog = false;
                canvasDude.SetActive(false);
                indexDialog = theDialogs.Count - 1;
            }
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if(obj.CompareTag("Player"))
        {
            canvasDude.SetActive(true);
            executeDialog = true;
            StartCoroutine(ShowDialogs());
        }
    }
}
