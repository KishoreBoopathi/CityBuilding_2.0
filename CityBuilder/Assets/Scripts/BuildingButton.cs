using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButton : MonoBehaviour
{
    public BuildingsData Building;
   public void OnPress()
    {
        FindObjectOfType<CubePlacer>().Prefab = Building.Model;
        FindObjectOfType<GameManager>().TakeAway(Building.StonePrice, Building.WoodPrice);
    }
}
