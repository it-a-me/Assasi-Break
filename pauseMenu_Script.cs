using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu_Script : MonoBehaviour
{

    private void Awake()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            Play();
        }
    }
    public void Play()
    {
        Destroy(gameObject);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScene");
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }


}
