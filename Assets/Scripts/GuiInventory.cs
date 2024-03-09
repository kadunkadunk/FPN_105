using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiInventory : MonoBehaviour
{
    public Button guiInventoryButton;
    public Inventory inventory = null;
    public GameObject inventoryListDropdown = GameObject.Find("InventoryListDropdown");
    // Start is called before the first frame update
    void Start()
    {
        guiInventoryButton = GameObject.Find("GetInventoryButton").GetComponent<Button>();
        guiInventoryButton.onClick.AddListener(OnClick);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Debug.Log("Button Clicked");
        
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
       
        inventory.inventoryItems.ForEach(delegate (GameObject go)
        {
            inventoryListDropdown.GetComponent<Dropdown>().options.Add(new Dropdown.OptionData() { text = go.name });
        });

        inventoryListDropdown.SetActive(true);

    }

    public void OnDropdownChange()
    {
        Debug.Log("Dropdown changed");
        inventory.useInventory(inventory.inventoryItems[inventoryListDropdown.GetComponent<Dropdown>().value]);
    }
}
