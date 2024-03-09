using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventoryItems;
    public GameObject useTool;
    

    public void addToInventory(GameObject goobject)
    {
        inventoryItems.Add(goobject);
        Debug.Log("Added to inventory: " + goobject.name);
    }

    public void removeInventory(GameObject goobject)
    {
        inventoryItems.Remove(goobject);
        Debug.Log("Removed from inventory: " + goobject.name);
    }

    public void useInventory(GameObject goobject)
    {
        useTool = goobject;
        Debug.Log("Using inventory: " + goobject.name);
    }
}
