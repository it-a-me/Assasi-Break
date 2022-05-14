using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSystemV3 : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    [SerializeField] private GameObject promptText;
    private bool wasPressed_G = false;

    [SerializeField] private GameObject chestOpen;
    [SerializeField] private GameObject chestClosed;
    private bool isClosed = true;
    private GameObject Chest;
    private void Update()
    {
        wasPressed_G = Input.GetKeyUp(KeyCode.G) || wasPressed_G;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        wasPressed_G = false;
        promptText.gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        promptText.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && wasPressed_G && isClosed)
        {
            OpenChest();
        }
        wasPressed_G = false;
    }
    private void OpenChest()
    {
        isClosed = false;
        chestOpen.SetActive(true);
        chestClosed.SetActive(false);
        int rItemNumber = Random.Range(0, items.Length - 1);
            Instantiate(items[rItemNumber]);
    //        Debug.LogError("tried to instantate a item that doesn't exist in chest");
    }
}


