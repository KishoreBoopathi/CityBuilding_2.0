using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestPoint : MonoBehaviour
{
    public Resource MyResource;
    public int resLeft = 100;
    public string WhiRes;
    public bool Harvested = false;
    public int HarvHere;
    GameManager GM;
    int TempAmount;
    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
        WhiRes = MyResource.Name;
    }
    private void OnMouseOver()
    {
        //Debug.Log("Mouse is over me: " + gameObject);
    }
    public void OnMouseDown()
    {
        //Debug.Log("Mouse has clicked me: " + gameObject);
        BuildingInfo BI = FindObjectOfType<BuildingInfo>();
        if (BI.Panel.activeSelf == false)
        {
            if (BI != null)
            {
                BI.Panel.SetActive(true);
                BI.Resource = gameObject;
                BI.SetData();
            }
            else
            {
                Debug.Log("BI doesnt exist");
            }
        }
        else
        {
            if (BI.Resource != gameObject)
            {
                BI.Building = null;
                BI.Resource = gameObject;
                BI.SetData();
            }
            else
            {
                if (GM.Harvesters > 0)
                {
                    GM.Harvesters--;
                    HarvHere++;
                    GM.Harv.text = "Labor Left: " + GM.Harvesters.ToString();
                    BI.HarvInc();
                    Harvested = true;
                }
                else
                {
                    Debug.LogError("Error cannot harvest this resource not enough Harvestors");
                }
            }
        }
    }
    public void Results()
    {
        int ResGain = Random.Range(MyResource.MinAmountToSpawn, MyResource.MaxAmountToSpawn);
        TempAmount = GM.Modifiers(WhiRes, ResGain) + ResGain;
        Debug.Log(TempAmount + " " + GM.Modifiers(WhiRes, ResGain));
        int hold = resLeft - TempAmount;
        if (hold >= 0)
        {
            resLeft -= TempAmount;
            //Debug.Log("Give player Resource: " + MyResource.Name + " amount given: " + TempAmount);
            GM.AddRes(WhiRes, TempAmount);
            //Harvested = false;
            //GM.TurnEnded = false;       
        }
        else
        {
            //Debug.Log("Give player Resource: " + MyResource.Name + " amount given: " + TempAmount);
            resLeft -= resLeft;
            GM.AddRes(WhiRes, resLeft);
            gameObject.SetActive(false);
        }
    }
}
