using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventoryItems;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToInventory(GameObject goobject)
    {
        inventoryItems.Add(goobject);
        Debug.Log("Added to inventory: " + goobject.name);
    }
}
