using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "New Building")]
public class BuildingsData : ScriptableObject
{
    public string Name;
    public GameObject Model;
    public string Description;
    [Header("Price")]
    public int StonePrice;
    public int WoodPrice;
    [Header("Stats")]
    public float WoodMod;
    public float StoneMod;
    public float FoodMod;
    public int HarvMod;
    public int Allies;
}
