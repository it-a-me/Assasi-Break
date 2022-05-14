using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorPanel_Script : MonoBehaviour
{
    public GameObject Text;
    public GameObject DoorPanel;
    private bool wasPressed_f = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        wasPressed_f = false;
        Text.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Text.gameObject.SetActive(false);
        DoorPanel.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (wasPressed_f)
        {
            DoorPanel.gameObject.SetActive(!DoorPanel.activeSelf);
            Text.gameObject.SetActive(!DoorPanel.activeSelf);
            wasPressed_f = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F)) {
            wasPressed_f = true;
            }
    }
}