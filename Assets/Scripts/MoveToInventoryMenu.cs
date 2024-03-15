using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveToInventoryMenu : MonoBehaviour
{
    public string sceneNameToLoad;
    public GameObject oldPlayer;
    public CollectibleItem collectibleItem;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("i"))
        {
            PlayerState();
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }

    public void PlayerState()
    {
        oldPlayer = GameObject.FindWithTag("Player");
        foreach(CollectibleItem ci in oldPlayer.GetComponent<Inventory>().inventoryItems)
        {
            Debug.Log(ci.name);
            PlayerManager.Instance.inventoryItems.Add(ci.name);
        }
        //PlayerManager.Instance.inventoryItems = oldPlayer.GetComponent<Inventory>().inventoryItems; 
        //PlayerManager.Instance.inventory = oldPlayer.GetComponent<Inventory>();
        //PlayerManager.Instance.inventoryItems = oldPlayer.GetComponent<Inventory>().inventoryItems;
        //inventory = player.GetComponent<Inventory>();
        //inventoryItems = player.GetComponent<Inventory>().inventoryItems;
        //foreach (GameObject go in inventoryItems)
        //{
        //    Debug.Log(inventoryItems.Count);
        //    inventoryNames.Add(go.name);
        //    Debug.Log(go.name);
        //}

    }
    public void OnClick()
    {
        Debug.Log("Button Clicked");
    }

}
