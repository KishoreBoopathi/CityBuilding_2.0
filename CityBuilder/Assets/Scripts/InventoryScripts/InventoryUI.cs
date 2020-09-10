using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform resourcesParent;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onResourceChangedCallback += UpdateUI;

        slots = resourcesParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.resources.Count)
            {
                slots[i].AddResource(inventory.resources[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
