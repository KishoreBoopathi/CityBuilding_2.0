using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMenu : MonoBehaviour
{
    public GameObject Debug_Menu;
    public bool DebugActive = false;
    private void Start()
    {
        Debug_Menu.SetActive(false);
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            DebugActive = !DebugActive;
            Debug_Menu.SetActive(DebugActive);
        }
    }
    public void Next()
    {
        if (SceneManager.GetActiveScene().buildIndex+1< SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            Debug.Log("No more Scenes.");
    }

    public void Previous()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
