using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonCaller : MonoBehaviour
{
    public void Update()
    {
        
    }
    public void OnMouseDown()
    {
        Debug.Log("Dungeon");
        FindObjectOfType<Player_Stats>().BDungeon = SceneManager.GetActiveScene().buildIndex;
        FindObjectOfType<GameManager>().SavePlayer();
        SceneManager.LoadScene("Hero");
    }
}
