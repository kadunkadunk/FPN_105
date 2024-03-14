using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUITerrain : MonoBehaviour
{
    public Button button;
    public TMP_Dropdown dropdown;
    public List<GameObject> list;
    public GameObject player;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {

        canvas =  GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
        Debug.Log("Canvas found");
        canvas.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            //_canvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
            canvas.gameObject.SetActive(true);
            Debug.Log("Canvas found"); ;
            Debug.Log(canvas.gameObject.name);
                      
            button = GameObject.Find("InventoryButton").GetComponent<Button>();
            dropdown = GameObject.Find("InventoryDropdown").GetComponent<TMP_Dropdown>();
            
            
            button.gameObject.SetActive(true);
            dropdown.gameObject.SetActive(true);

            dropdown.options.Clear();
            dropdown.options.RemoveAll(delegate { return true; }); 
            //button.onClick.AddListener(OnClick);
            PopulateDropdown();

        }
    }

    void PopulateDropdown()
    {
        player = GameObject.FindWithTag("Player");
        list = player.GetComponent<Inventory>().inventoryItems;
        foreach (GameObject go in list)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = go.name });
        }

    }

    public void OnDropdownChange()
    {
        Debug.Log("Dropdown changed");
        player.GetComponent<Inventory>().useInventory(list[dropdown.value]);
    }

    public void OnClick()
    {
        Debug.Log("Button Clicked");
        canvas.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
}
