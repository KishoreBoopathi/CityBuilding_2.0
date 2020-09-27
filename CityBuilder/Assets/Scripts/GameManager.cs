using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player Stats")]
    public float WoodMod;
    public float StoneMod;
    public float FoodMod;
    public float Harvesters = 1;
    public Text Harv;
    [Header("Player Resources")]
    public int Wood;
    public Text WText;
    public int Stone;
    public Text SText;
    public int Food;
    public int Allies;
    [Header("ToTake")]
    public int STake;
    public int WTake;
    //public List<GameObject> Buildings; //Test Variable
    //public int BNum;
    public bool TurnEnded;
    int TempMod;
    public struct bData
    {
        public string name;
        public Vector3 pos;
    }
    public List<bData> BuildingList;
    List<bData> sBuildingList;
    public void Start()
    {
        TextValues();
        UpdateRes();
        Harv.text = "Labor Left: " + Harvesters.ToString();
        string path = Application.persistentDataPath + "/player.data";
        Debug.Log(path);
        BuildingList = new List<bData>();
        sBuildingList = new List<bData>();

        //Button btn = GameObject.Find("EndButton").GetComponent<Button>();
        //Debug.Log(btn);
        //btn.onClick.AddListener(EndTurn);
    }
    public void EndTurn()
    {
        TurnEnded = true;
        foreach (HarvestPoint HPoint in FindObjectsOfType<HarvestPoint>())
        {
            if (HPoint.Harvested == true)
            {
                while (HPoint.HarvHere > 0)
                {
                    HPoint.Results();
                    Harvesters++;
                    HPoint.HarvHere--;
                }
                HPoint.Harvested = false;
                TextValues();
            }
        }
        foreach (Building Built in FindObjectsOfType<Building>())
        {
            if (Built.isBuilt == false)
            {
                Built.TTComplete -= 1;
                Built.BUpdate();
            }
        }
        BuildingInfo BI = FindObjectOfType<BuildingInfo>();
        if (BI != null) 
            BI.SetData();

        Harv.text = "Labor Left: " + Harvesters.ToString();
        TurnEnded = false;
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
                TempMod = Mathf.RoundToInt(BGain * FoodMod);
                break;
        }
        //Debug.Log("Value Returned: " + TempMod + " from case Value: " + WRes);
        return TempMod;
    }
    public void TakeAway(int Ston, int Woo)
    {
        //Only for test purpose to showcase amount being taken
        STake = Ston;
        WTake = Woo;
    }
    public bool CanPlace()
    {
        if (Stone - STake >= 0 && Wood - WTake >= 0)
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
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        foreach (var item in BuildingList)
        {
            sBuildingList.Add(item);
        }
    }
    public void LoadPlayer()
    {
        List<GameObject> trash = new List<GameObject>();

        GameObject objectList = GameObject.Find("ObjectList");
        if (objectList != null)
        {
            foreach (Transform item in objectList.transform)
            {
                trash.Add(item.gameObject);
            }
        }
        BuildingList.Clear();
        BuildingMenu bm = FindObjectOfType<BuildingMenu>();
        CubePlacer cp = FindObjectOfType<CubePlacer>();
        foreach (var item in sBuildingList)
        {
            foreach (var i in bm.buildingsList)
            {
                if (i.Name == item.name)
                {
                    cp.PlaceCube(i, item.pos);
                    break;
                }
            }
        }

        PlayerData data = SaveSystem.LoadPlayer();
        Wood = data.Wood;
        Debug.Log(Wood);
        Stone = data.Stone;
        Food = data.Food;
        Harvesters = data.Harvesters;
        UpdateRes();
        foreach (var item in trash)
        {
            Destroy(item);
        }
    }

    public void AddnewBuilding(string name, Vector3 position)
    {
        bData data = new bData();
        data.name = name;
        data.pos = position;
        BuildingList.Add(data);
    }

    public void TextValues()
    {
        if (WText == null)
        {
            WText = GameObject.Find("WoodText").GetComponent<Text>();
        }
        if (SText == null)
        {
            SText = GameObject.Find("StoneText").GetComponent<Text>();
        }
        if (Harv == null)
        {
            Harv = GameObject.Find("HarvestorText").GetComponent<Text>();
        }
        UpdateRes();
    }
}

