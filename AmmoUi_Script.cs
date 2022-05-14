using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUi_Script : MonoBehaviour
{
    [SerializeField] private Inventory_Scriot pInv;
    private Text text;

    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        text.text = pInv.GetAmmo().ToString(); 
    }
}
