using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInfo : MonoBehaviour
{
    [Header("Manager")]
    public GameObject Panel;
    [Header("Building Panel Data")]
    public GameObject Building;
    public Text Name;
    private void Start()
    {
        Panel.SetActive(false);
        Building = null;
    }
    public void SetData()
    {
        Name.text = Building.GetComponent<Building>().Data.Name;
    }
}
