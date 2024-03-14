using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUITerrain : MonoBehaviour
{
    public Button button;
    private TMP_Dropdown _dropdown;
    private List<GameObject> _list;
    private GameObject _player;
    private Canvas _canvas;
    // Start is called before the first frame update
    void Start()
    {
        _canvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
        _canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _canvas.gameObject.SetActive(true);
           
            button = GameObject.Find("InventoryButton").GetComponent<Button>();
            _dropdown = GameObject.Find("InventoryDropdown").GetComponent<TMP_Dropdown>();
            
            
            button.gameObject.SetActive(true);
            _dropdown.gameObject.SetActive(true);

            _dropdown.options.Clear();
            //button.onClick.AddListener(OnClick);
            PopulateDropdown();

        }
    }

    void PopulateDropdown()
    {
        _player = GameObject.FindWithTag("Player");
        _list = _player.GetComponent<Inventory>().inventoryItems;
        foreach (GameObject go in _list)
        {
            _dropdown.options.Add(new TMP_Dropdown.OptionData() { text = go.name });
        }

    }

    public void OnDropdownChange()
    {
        Debug.Log("Dropdown changed");
        _player.GetComponent<Inventory>().useInventory(_list[_dropdown.value]);
    }

    public void OnClick()
    {
        Debug.Log("Button Clicked");
        _canvas.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
}
