using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingsData Data;
    public int TTComplete;
    public bool isBuilt;    
    GameManager GM;
    void Start()
    {
        isBuilt = false;
        //On spawn Reference Player Stats. Increase Yield Modifier or Increase Harvestors.
        GM = FindObjectOfType<GameManager>();       
    }

    //OnMouseDown (Clicked) Display Selected Building and if can upgrade give option and required resources
    public void OnMouseOver()
    {
        Debug.Log("Hello");
    }
    public void OnMouseDown()
    {
        BuildingInfo BI = FindObjectOfType<BuildingInfo>();
        if (BI == null) return;
        if (BI.Panel.activeSelf == false)
        {
            if (BI != null)
            {
                BI.Panel.SetActive(true);
                BI.Building = gameObject;
                BI.SetData();
            }
            else
            {
                Debug.Log("BI doesnt exist");
            }
        }
        else 
        {
            if (BI.Building != gameObject)
            {
                BI.Resource = null;
                BI.Building = gameObject;
                BI.SetData();
            }
        }
    }
    //Upgrade Function if not max level allow upgrade show required Resources and Turns
    public void BUpdate()
    {
        if(TTComplete == 0 && isBuilt == false)
        {
            isBuilt = true;
            ResIncrease(Data.Name, Data.HarvMod);
        }
    }

    public void ResIncrease(string R_Name, int IncHarv)
    {
        Debug.Log(R_Name);
        switch(R_Name)
        {
            case "Workshop":
                GM.WoodMod += Data.WoodMod;
                break;
            case "House":
                GM.Harvesters += IncHarv;
                break;        
        }
       
    }
}
