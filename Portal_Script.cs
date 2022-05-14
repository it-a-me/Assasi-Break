using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal_Script : MonoBehaviour
{
    [SerializeField] private string Next_Level_Name;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(Next_Level_Name);
        }
    }



}
