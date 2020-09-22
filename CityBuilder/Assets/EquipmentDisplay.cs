using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentDisplay : MonoBehaviour
{
    public enum Slot
    {
        Helm,
        Chest,
        Boots,
        Sword,
        Shield
    }
    
    public Slot Place;
    public Sprite Icon;
    public GameObject Model;
    [Header("Stats")]
    public int MinHp;
    public int MaxHp;
    public int MinAtk;
    public int MaxAtk;
    public int MinDef;
    public int MaxDef;
    public int MinMana;
    public int MaxMana;
    //Equipment : ScriptableObject




}
