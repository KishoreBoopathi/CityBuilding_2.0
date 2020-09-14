using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int Wood;
    public int Stone;
    public int Food;
    public float Harvesters;

    public PlayerData(GameManager gamemanager)
        {
            Wood = gamemanager.Wood;
            Stone = gamemanager.Stone;
            Food = gamemanager.Food;
            Harvesters = gamemanager.Harvesters;

        }
}
