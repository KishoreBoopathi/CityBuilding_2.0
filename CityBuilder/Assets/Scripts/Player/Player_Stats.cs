using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Stats : MonoBehaviour
{
    public static GameObject instance;
    public int BDungeon;
    [Header("Player Stats")]
    public int Str;
    public List<GameObject> Equipment;

    public void Awake()
    {
        if (instance == null)
        {
            instance = gameObject;
        }

        if (instance != gameObject)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
