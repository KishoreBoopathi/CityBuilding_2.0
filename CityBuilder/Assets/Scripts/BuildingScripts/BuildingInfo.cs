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
    public Text HarveHere;
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
            HarveHere.gameObject.SetActive(false);
        }
        if(Resource != null)
        {
            Name.text = Resource.GetComponent<HarvestPoint>().MyResource.Name;           
            ResourceLeft.text = Resource.GetComponent<HarvestPoint>().resLeft.ToString();
            HarveHere.gameObject.SetActive(true);
            HarveHere.text = "Harvesters here " + Resource.GetComponent<HarvestPoint>().HarvHere.ToString();
        }      
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit ))
            {
                //Debug.Log("Hit something");
                Debug.Log("hit " + hit.collider.gameObject.name);
            }
            else
            {
                //Check if terrain to turn this off
                Panel.SetActive(false);
                Building = null;
                Resource = null;
            }
        }
    }
    public void Close()
    {
        Panel.SetActive(false);
        Building = null;
        Resource = null;
    }
    public void HarvInc()
    {
        HarveHere.text = "Harvesters here " + Resource.GetComponent<HarvestPoint>().HarvHere.ToString();
    }
}
