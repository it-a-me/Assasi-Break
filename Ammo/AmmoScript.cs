using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoScript : MonoBehaviour
{
    private AmmoUi_Script ammoUi_Script;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<Inventory_Scriot>().AddAmmo(Random.Range(1, 5));
            Destroy(gameObject);
            
        }
    }
}
