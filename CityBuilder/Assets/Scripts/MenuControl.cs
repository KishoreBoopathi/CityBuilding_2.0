using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public int i = 0;
    public GameObject MainMenu;
    public GameObject SettingsMenu;
    // Start is called before the first frame update

    public void Play()
    {
        i = Random.Range(1, 2);
        if (i == 1)
        {
            Debug.Log("Yu's Level");
            SceneManager.LoadScene("Yu Test");
        }
        else if (i == 2)
        {
            Debug.Log("Doug's Level");
            SceneManager.LoadScene("Winter Biome");
        }
        i = 0;
    }
    // Update is called once per frame
    public void Settings()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }
    public void Quit()
    {
        
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void Back()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }
    
}
