using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuiInventory : MonoBehaviour
{
    public Inventory inventory = null;
    public List<GameObject> inventoryItems;
    public TMP_Dropdown inventoryListDropdown;
    public GameObject newplayer;
   
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerManager.Instance != null)
        {
            newplayer = PlayerManager.Instance.player;
            inventory = PlayerManager.Instance.inventory;
            inventoryItems = PlayerManager.Instance.inventoryItems;
            Debug.Log(inventory.inventoryItems.Count);
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
            //Debug.Log(inventory.inventoryItems[0].name);
            foreach (GameObject go in inventoryItems)
            {
                Debug.Log(go.name);
                inventoryListDropdown.GetComponent<Dropdown>().options.Add(new Dropdown.OptionData() { text = go.name });
            }
        }

    }

    public void OnDropdownChange()
    {
        Debug.Log("Dropdown changed");
        inventory.useInventory(inventory.inventoryItems[inventoryListDropdown.GetComponent<Dropdown>().value]);
    }
}
