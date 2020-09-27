using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform resourcesParent;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;

    public GameObject PlayerStats;
    bool isPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.SetActive(isPlayer);
        inventory = Inventory.instance;
        inventory.onResourceChangedCallback += UpdateUI;

        slots = resourcesParent.GetComponentsInChildren<InventorySlot>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            isPlayer = !isPlayer;
            PlayerStats.SetActive(isPlayer);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.resources.Count)
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
