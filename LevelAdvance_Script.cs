using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAdvance_Script : MonoBehaviour
{
    [SerializeField] private Transform KeyParent;
    [SerializeField] private GameObject Portal;
    [SerializeField] private GameObject Door;
    void Update()
    {
       if (KeyParent.childCount == 0)
        {
            Door.SetActive(false);
            Portal.SetActive(true);
            Destroy(this);
        }
    }
}
