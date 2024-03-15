using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<CollectibleItem> inventoryItems;
    public GameObject useTool;
    

    public void addToInventory(CollectibleItem item)
    {
        inventoryItems.Add(item);
        Debug.Log("Added to inventory: " + item.name);
    }

    public void removeInventory(CollectibleItem item)
    {
        inventoryItems.Remove(item);
        Debug.Log("Removed from inventory: " + item.name);
    }

    public void useInventory(CollectibleItem item)
    {
        useTool = item;
        Debug.Log("Using inventory: " + item.name);
    }
}
