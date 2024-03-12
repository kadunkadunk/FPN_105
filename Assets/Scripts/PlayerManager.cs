using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public GameObject player;
    public Inventory inventory;
    public List<GameObject> inventoryItems; 
    
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        inventory = player.GetComponent<Inventory>();
        inventoryItems = inventory.inventoryItems;
        

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
