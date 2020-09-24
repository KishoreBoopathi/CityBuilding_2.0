using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate ()
        {
            OnClick(param);
        });
    }
}
public class BuildingMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public List<BuildingsData> buildingsList;
    // Start is called before the first frame update
    void Start()
    {
        GameObject actionButton = transform.GetChild(0).gameObject;
        GameObject backButton = transform.GetChild(1).gameObject;
        GameObject actionSlot;
        for (int i = 0; i < buildingsList.Count; i++)
        {
            actionSlot = Instantiate(actionButton, transform);
            actionSlot.transform.GetChild(0).GetComponent<Image>().sprite = buildingsList[i].Model.GetComponent<Image>().sprite;
            actionSlot.transform.GetChild(1).GetComponent<Text>().text = buildingsList[i].Name;
            actionSlot.transform.GetChild(2).GetComponent<Text>().text = buildingsList[i].Description;

            /*actionSlot.GetComponent<Button>().onClick.AddListener(delegate ()
            {
                SlotPressed(buildingsList[i]);
            });*/

            actionSlot.GetComponent<Button>().AddEventListener(buildingsList[i], SlotPressed);
        }
        actionSlot = Instantiate(backButton, transform);
        Destroy(actionButton);
        Destroy(backButton);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SlotPressed(BuildingsData building)
    {
        Debug.Log("Building Name: " + building.Name);
        FindObjectOfType<CubePlacer>().data = building;
        //FindObjectOfType<CubePlacer>().pgo = Instantiate(building.Model);
        FindObjectOfType<GameManager>().TakeAway(building.StonePrice, building.WoodPrice);
    }

    public void OnBackButtonPressed()
    {
        FindObjectOfType<CubePlacer>().data = null;
        Destroy(FindObjectOfType<CubePlacer>().pgo);
        gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}
