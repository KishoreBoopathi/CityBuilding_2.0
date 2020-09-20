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
    [Header("Resource Panel Data")]
    public GameObject Resource;
    public Text ResourceLeft;
    private void Start()
    {
        Panel.SetActive(false);
        Building = null;
        Resource = null;
    }
    public void SetData()
    {
        if (Building != null)
        {
            Name.text = Building.GetComponent<Building>().Data.Name;
            ResourceLeft.text = Building.GetComponent<Building>().Data.Description.ToString();
        }
        if(Resource != null)
        {
            Name.text = Resource.GetComponent<HarvestPoint>().MyResource.Name;           
            ResourceLeft.text = Resource.GetComponent<HarvestPoint>().resLeft.ToString();
        }      
    }
    public void Close()
    {
        Panel.SetActive(false);
        Building = null;
        Resource = null;
    }
}
