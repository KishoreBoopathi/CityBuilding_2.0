using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ResourceAmount
{
    public Resource resource;
    public int amount;
}

[CreateAssetMenu(fileName = "New Crafting", menuName = "New Crafting")]
public class CraftingRecipe: ScriptableObject
{
    public string Name;
    public List<ResourceAmount> Materials;
    public ResourceAmount CraftedResource;
}
