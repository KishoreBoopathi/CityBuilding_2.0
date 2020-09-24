using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Equipment")]
public class Equipment : ScriptableObject 
{
    public new string name;
    public string description;

    public Sprite artwork;

    public int attack;
    public int health;

    public void Print ()
    {
       
    }
}
