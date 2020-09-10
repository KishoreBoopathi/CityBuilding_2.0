using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "New Building")]
public class BuildingsData : ScriptableObject
{
    public string Name;
    public GameObject Model;
    [Header("Price")]
    public int StonePrice;
    public int WoodPrice;
}
