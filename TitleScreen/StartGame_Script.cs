using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame_Script : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject UniObject;
    private void Awake()
    {
        Time.timeScale = 1;
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Permanent")){
            Destroy(o);
        }
        Instantiate(UniObject);
    }
    [SerializeField]
    private string Tutorial_Name = "Tutorial";
    public void ChangeScene()
    {
        SceneManager.LoadScene("Tutorial");    
    }
    
}
