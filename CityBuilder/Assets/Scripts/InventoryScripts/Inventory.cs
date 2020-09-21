using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;   

    private void Awake()
    {
        if(instance!=null)
        {
            Debug.LogWarning("More than one instance of inventory is being created.");
            return;
        }
        instance = this;
    }
    #endregion

    public List<Resource> resources = new List<Resource>();

    public delegate void OnResourceChanged();
    public OnResourceChanged onResourceChangedCallback;

    public int InventorySize = 30;

    public bool Add(Resource resource)
    {
        if(resources.Count > 0)
        {
            for (int i = 0; i < resources.Count; i++)
            {
                if (resources[i].Name.Equals(resource.Name))
                {
                    if (resources[i].AmountInInventory + resource.SpawnedAmount < resource.MaxCountToStore)
                    {
                        resources[i].AmountInInventory += resource.SpawnedAmount;

                        if (onResourceChangedCallback != null)
                            onResourceChangedCallback.Invoke();

                        return true;
                    }
                    else
                    {
                        Debug.LogWarning("Max limit for the resource reaached.");
                        return false;
                    }
                }
            }
        }

        if (resources.Count >= InventorySize)
        {
            Debug.LogWarning("Not enough space in inventory");
            return false;
        }
        resources.Add(resource);

        if (onResourceChangedCallback != null)
            onResourceChangedCallback.Invoke();

        return true;
    }

    public void Remove(Resource resource)
    {
        resources.Remove(resource);

        if (onResourceChangedCallback != null)
            onResourceChangedCallback.Invoke();
    }
}
