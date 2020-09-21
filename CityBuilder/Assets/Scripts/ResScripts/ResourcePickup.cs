using UnityEngine;

public class ResourcePickup : MonoBehaviour
{
    public Resource resource;

    private void OnMouseDown()
    {
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picked up " + resource.SpawnedAmount + " " + resource.Name);
        bool isAddedToInventory = Inventory.instance.Add(resource);
        if(isAddedToInventory)
        {
            Destroy(gameObject);
        }
    }
}
