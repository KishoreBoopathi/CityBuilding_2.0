using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Player Stats")]
    public float WoodMod;
    public float StoneMod;
    public float FishMod;
    public float Harvesters;
    public Text Harv;
    [Header("Player Resources")]
    public int Wood;
    public Text WText;
    public int Stone;
    public Text SText;
    public int Food;
    [Header("ToTake")]
    public int STake;
    public int WTake;
    //public List<GameObject> Buildings; //Test Variable
    //public int BNum;
    public bool TurnEnded;
    int TempMod;

    public void Start()
    {
        UpdateRes();
        Harv.text = "Labor Left: " + Harvesters.ToString();
    }
    public void EndTurn()
    {
        TurnEnded = true;
        foreach (HarvestPoint HPoint in FindObjectsOfType<HarvestPoint>())
        {
            if (HPoint.Harvested == true)
            {
                HPoint.Results();
                HPoint.Harvested = false;
                TurnEnded = false;
                Harvesters++;
                Harv.text = "Labor Left: " + Harvesters.ToString();
                UpdateRes();
            }
        }
    }

    public void AddRes(string Res, int Amount)
    {
        switch (Res)
        {
            case "Wood":
                Wood += Amount;
                break;
            case "Stone":
                Stone += Amount;
                break;
            case "Food":
                Food += Amount;
                break;
        }        
    }
    public int Modifiers(string WRes, int BGain)
    {
        switch (WRes)
        {
            case "Wood":
                TempMod = Mathf.RoundToInt(BGain * WoodMod);
                break;
            case "Stone":
                TempMod = Mathf.RoundToInt(BGain * StoneMod);
                break;
            case "Food":
                TempMod = Mathf.RoundToInt(BGain * FishMod);
                break;
        }
        //Debug.Log("Value Returned: " + TempMod + " from case Value: " + WRes);
        return TempMod;
    }
    public void TakeAway(int Ston,int Woo)
    {
        //Only for test purpose to showcase amount being taken
        STake = Ston;
        WTake = Woo;
    }
    public bool CanPlace()
    {
        if(Stone - STake >= 0 && Wood - WTake >= 0)
        {
             Stone -= STake;
             Wood -= WTake;
             UpdateRes();
             return true;
        }
        else
        {
            return false;
        }
    }
    public void UpdateRes()
    {
        WText.text = "Wood: " + Wood.ToString();
        SText.text = "Stone: " + Stone.ToString();
    }
    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.G))
    //    {
    //        //This is for CubePlacer Test
    //        BNum++;
    //        if (Buildings.Count <= BNum)
    //        {
    //            BNum = 0;
    //        }
          
    //        FindObjectOfType<CubePlacer>().Prefab = Buildings[BNum];

    //    }
    //}
}
