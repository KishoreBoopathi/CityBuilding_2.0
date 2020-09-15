using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void ToJungle()
    {
        SceneManager.LoadScene("Jungle Biome");
    }

    public void ToWinter()
    {
        SceneManager.LoadScene("Winter Biome");
    }

    public void ToDesert()
    {
        SceneManager.LoadScene("Yu Test");
    }

    public void ToSky()
    {
        SceneManager.LoadScene("Sky Island");
    }
    public void rlevel()
    {
        SceneManager.LoadScene(Random.Range(1, 4));
    }
}
