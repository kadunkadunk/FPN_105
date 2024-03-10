using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiInventory : MonoBehaviour
{
    public Inventory inventory = null;
    public GameObject inventoryListDropdown;
    [SerializeField]
    private GameObject player = null;
    // Start is called before the first frame update
    void Start()
    {
        inventoryListDropdown = GameObject.Find("InventoryListDropdown");
        GameObject newPlayer = Instantiate(player);
        inventory = newPlayer.GetComponent<Inventory>();
        //inventory = GameObject.Find("Player").GetComponent<Inventory>();
        if (inventory != null)
        {
            Debug.Log("Inventory is not null");
            Debug.Log(inventory.inventoryItems.Count);
            inventory.inventoryItems.ForEach(delegate (GameObject go)
            {
                Debug.Log(go.name);
                //inventoryListDropdown.
                //.GetComponent<Dropdown>().options.Add(new Dropdown.OptionData() { text = go.name });
            });
        }
        inventoryListDropdown.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Debug.Log("Button Clicked");

        if (inventory != null)
        {
            inventory.inventoryItems.ForEach(delegate (GameObject go)
            {
                inventoryListDropdown.GetComponent<Dropdown>().options.Add(new Dropdown.OptionData() { text = go.name });
            });
        }
        inventoryListDropdown.SetActive(true);

    }

    public void OnDropdownChange()
    {
        Debug.Log("Dropdown changed");
        inventory.useInventory(inventory.inventoryItems[inventoryListDropdown.GetComponent<Dropdown>().value]);
    }
}
