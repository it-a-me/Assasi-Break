using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int scene;
    public void NextScene()
    {
        SceneManager.LoadScene(scene);
    }
}
