using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestButtonOnScreen : MonoBehaviour
{
    public Button testButton;
    public string sceneNameToLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        //testButton = GameObject.Find("InventoryButton").GetComponent<Button>();
        //testButton.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("i"))
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }

    public void OnClick()
    {
        Debug.Log("Button Clicked");
    }

}
