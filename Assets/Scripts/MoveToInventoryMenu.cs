using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveToInventoryMenu : MonoBehaviour
{
    public Button testButton;
    public string sceneNameToLoad;
    public GameObject oldPlayer;
    
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
        PlayerManager.Instance.player = oldPlayer;
        PlayerManager.Instance.inventory = oldPlayer.GetComponent<Inventory>();
        //PlayerManager.Instance.inventoryItems = oldPlayer.GetComponent<Inventory>().inventoryItems;
                
    }
    public void OnClick()
    {
        Debug.Log("Button Clicked");
    }

}
