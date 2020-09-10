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
        if(resources.Count >= InventorySize)
        {
            Debug.LogWarning("Not enough space in inventory");
            return false;
        }
        resources.Add(resource);

        if(onResourceChangedCallback != null)
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
