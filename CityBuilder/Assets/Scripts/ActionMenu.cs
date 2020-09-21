using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMenu : MonoBehaviour
{
    public List<GameObject> Actions;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPressedBuildingButton()
    {
        this.gameObject.SetActive(false);
        foreach(GameObject menu in Actions)
        {
            if(menu.name.Equals("Building Menu"))
            {
                menu.SetActive(true);
                return;
            }
        }
    }

    public void OnPressedCraftingButton()
    {
        this.gameObject.SetActive(false);
        foreach(GameObject menu in Actions)
        {
            if(menu.name.Equals("Crafting Menu"))
            {
                menu.SetActive(true);
                return;
            }
        }
    }
}