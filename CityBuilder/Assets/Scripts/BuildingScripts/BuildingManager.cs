using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    public GameObject[] buildings;
    private BuildingPlacement buildingPlacement;

    void Start()
    {
        buildingPlacement = GetComponent<BuildingPlacement>();
    }

    void Update()
    {

    }

    public void PickBuilding(int number)
    {
        buildingPlacement.SetItem(buildings[number]);
    }
}