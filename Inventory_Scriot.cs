using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Scriot : MonoBehaviour
{
    private int currentInv = 0;
    private GameObject cItem;
    private float altDamage;
    [SerializeField] private List<GameObject> items = new List<GameObject>();
    public int ammo = 44;

    void Start()
    {
        if (items.Count > 0)
        {
            cItem = Instantiate(items[currentInv], gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0 && items.Count > 0)
        {

            if (Input.GetKeyUp(KeyCode.Q))
            {
                currentInv += 1;
                if (currentInv < items.Count)
                {
                    SetInventory(currentInv);
                }
                else if (currentInv == items.Count)
                {
                    GameObject.Destroy(cItem);
                }
                else if (currentInv > items.Count)
                {
                    currentInv = 0;
                    SetInventory(currentInv);
                }
            }
        }
    }

    public string SetInventory(int inv)
    {
        if (cItem != null)
        {
            Destroy(cItem);
        }
        cItem = Instantiate(items[inv], transform);
        if (cItem.GetComponent<gun>() != null && altDamage > 0)
        {
            cItem.GetComponent<gun>().SetDamage(altDamage);
        }
        return cItem.transform.name;

    }

    public float SetDamage(float newDamage)
    {
        altDamage = newDamage;
        return altDamage;
    }

    public void AddItem(GameObject newItem)
    {
        items.Add(newItem);
    }

    public int SetAmmo(int newAmmo)
    {
        ammo = newAmmo;
        return ammo;
    }

    public int GetAmmo()
    {
        return ammo;
    }
    public int AddAmmo(int moreAmmo)
    {
        ammo += moreAmmo;
        return ammo;
    }
}

