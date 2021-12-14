using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Load(string destination)
    {
        SceneManager.LoadScene(destination);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
