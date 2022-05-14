using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class UniObject_Script : MonoBehaviour
{
    [SerializeField]
    private GameObject PauseScreen;
    private GameObject ui;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P) && SceneManager.GetActiveScene().name != "TitleScene")
        {
            if (ui == null)
            {
                Pause();
            }
        }
    }
    private void Pause()
    {
        ui = Instantiate(PauseScreen);
    }
}



