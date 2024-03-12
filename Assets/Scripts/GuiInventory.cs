using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuiInventory : MonoBehaviour
{
    
    public List<string> inventoryItems;
    public TMP_Dropdown inventoryListDropdown;
   
   
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerManager.Instance != null)
        {
            
            inventoryItems = PlayerManager.Instance.inventoryItems;
            Debug.Log(inventoryItems.Count);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            inventoryListDropdown = GameObject.Find("InventoryListDropdown").GetComponent<TMP_Dropdown>();
            inventoryListDropdown.GetComponent<TMP_Dropdown>().ClearOptions();
        }
        else
        {
            Debug.Log("PlayerManager is null");
        }       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Debug.Log("Button Clicked");

        if (inventoryItems.Count > 0)
        {
            Debug.Log("Inventory has items");
            Debug.Log(inventoryItems.Count);
            foreach (string go in inventoryItems)
            {
                Debug.Log(go);
                inventoryListDropdown.options.Add(new TMP_Dropdown.OptionData() { text = go });
            }

        }

    }

    public void OnDropdownChange()
    {
        Debug.Log("Dropdown changed");
        //inventory.useInventory(inventory.inventoryItems[inventoryListDropdown.GetComponent<Dropdown>().value]);
    }
}
