using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/*public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate ()
        {
            OnClick(param);
        });
    }
}*/

public class CraftingMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public List<CraftingRecipe> craftsList;
    // Start is called before the first frame update
    void Start()
    {
        GameObject actionButton = transform.GetChild(0).gameObject;
        GameObject backButton = transform.GetChild(1).gameObject;
        GameObject actionSlot;
        for (int i = 0; i < craftsList.Count; i++)
        {
            actionSlot = Instantiate(actionButton, transform);
            actionSlot.transform.GetChild(0).GetComponent<Text>().text = craftsList[i].Name;
            actionSlot.transform.GetChild(1).GetComponent<Image>().sprite = craftsList[i].Materials[0].resource.icon;
            actionSlot.transform.GetChild(2).GetComponent<Image>().sprite = craftsList[i].Materials[1].resource.icon;
            actionSlot.transform.GetChild(3).GetComponent<Image>().sprite = craftsList[i].CraftedResource.resource.icon;

            /*actionSlot.GetComponent<Button>().onClick.AddListener(delegate ()
            {
                SlotPressed(buildingsList[i]);
            });*/

            actionSlot.GetComponent<Button>().AddEventListener(craftsList[i], SlotPressed);
        }
        actionSlot = Instantiate(backButton, transform);
        Destroy(actionButton);
        Destroy(backButton);
    }

    void SlotPressed(CraftingRecipe craft)
    {
        Debug.Log("Crafting: " + craft.Name);
       /* FindObjectOfType<CubePlacer>().data = building;
        FindObjectOfType<GameManager>().TakeAway(building.StonePrice, building.WoodPrice);*/
    }
    public void OnBackButtonPressed()
    {
        this.gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}
