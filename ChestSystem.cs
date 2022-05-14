using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSystem : MonoBehaviour
{
    public GameObject[] items;
    public int[] table =
    {
        60,
        30,
        10
    };

    private Component Chest;
    public int total;
    public int randomNumber;
    public GameObject Text;
    public GameObject ChestClosed;
    public GameObject ChestOpen;
    private bool wasPressed_f = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        wasPressed_f = false;
        Text.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Text.gameObject.SetActive(false);
    }

    private void Start()
    {
        foreach(var item in table)
        {
            total += item;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            randomNumber = Random.Range(0, total);
            Destroy(this);

            for(int i = 0; i < table.Length; i++)
            {
                if (randomNumber <= table[i])
                {
                    Text.SetActive(false);
                    ChestOpen.SetActive(true);
                    ChestClosed.SetActive(false);
                    Instantiate(items[i], transform.position, Quaternion.identity);
                    return;
                }
                else
                {
                    randomNumber -= table[i];
                }
            }

            
        }
        
    }
}


