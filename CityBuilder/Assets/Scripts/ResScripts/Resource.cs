using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Resource", menuName = "New Resource")]
public class Resource : ScriptableObject
{
    public string Name;
    public Sprite icon;
    public int MinAmountToSpawn;
    public int MaxAmountToSpawn;
    public int MaxCountToStore;

    public virtual void UseResource ()
    {
        //Usage of the resource

        Debug.Log("Using " + Name);
    }
}

