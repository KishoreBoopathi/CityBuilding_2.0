using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public Image resourceIcon;
    public Button removeButton;
    public Image resourceCountImage;
    public Text resourceCountText;

    Resource resource;
    

    public void AddResource(Resource newResource)
    {
        resource = newResource;

        resourceIcon.sprite = resource.icon;
        resourceIcon.enabled = true;
        resourceCountImage.color = new Color(resourceCountImage.color.r, resourceCountImage.color.g, resourceCountImage.color.b, 1f);
        resourceCountText.color = new Color(resourceCountText.color.r, resourceCountText.color.g, resourceCountText.color.b, 1f);
        removeButton.interactable = true;
    }

    public void ClearSlot ()
    {
        resource = null;

        resourceIcon.sprite = null;
        resourceIcon.enabled = false;
        resourceCountImage.color = new Color(resourceCountImage.color.r, resourceCountImage.color.g, resourceCountImage.color.b, 0f);
        resourceCountText.color = new Color(resourceCountText.color.r, resourceCountText.color.g, resourceCountText.color.b, 0f);
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(resource);
    }
    
    public void UseResource ()
    {
        if(resource != null)
        {
            resource.UseResource();
            ClearSlot();
        }
    }

}
