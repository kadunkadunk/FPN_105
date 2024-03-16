using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System;

[RequireComponent(typeof(AudioSource))]
public class ItemCollect : MonoBehaviour 
{
    public Inventory inventory;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject player;
    public CollectibleItem item;
    
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
     void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("Mouse down event");
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit, 3))
        //    {
        //        player = GameObject.FindWithTag("Player");
        //        inventory = player.GetComponent<Inventory>();
        //        GameObject paperclip = inventory.inventoryItems.Find(x => x.name == "Paperclip");
        //        Debug.Log("Paperclip found in inventory: " + paperclip);

        //        Debug.Log(hit.transform.name);
        //        if (inventory != null)
        //        {
        //            Debug.Log("Inventory is not null");
        //            if (paperclip != null)
        //            {
        //                Debug.Log("Paperclip created");
        //                //audioSource.Play();
        //                Instantiate(paperclip, hit.point, Quaternion.identity);
        //                paperclip.SetActive(true);
        //            }
        //        }
        //        else
        //        {
        //            Debug.Log("Inventory is null");
        //        }
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventory = other.GetComponent<Inventory>();

            switch (this.name)
            {
                case "Paperclip":
                    Debug.Log("Paperclip collected");
                    item = this.GetComponent<CollectibleItem>();
                    inventory.addToInventory(item);
                    inventory.useTool = item;
                    break;
                case "Key1":
                    Debug.Log("Key collected");
                    item = this.GetComponent<CollectibleItem>();
                    inventory.addToInventory(item);
                    inventory.useTool = item;
                    break;
                case "Shovel":
                    Debug.Log("Shovel collected");
                    item = this.GetComponent<CollectibleItem>();
                    inventory.addToInventory(item);
                    inventory.useTool = item;
                    break;
                case "Hammer":
                    Debug.Log("Hammer collected");
                    item = this.GetComponent<CollectibleItem>();
                    inventory.addToInventory(item);
                    inventory.useTool = item;
                    break;
            }
            audioSource= this.GetComponent<AudioSource>();
            audioSource.Play();
            Invoke("DestroyItem", 2.0f);

        }
    }
    public void DestroyItem()
    {
        gameObject.SetActive(false);// Destroy(gameObject);
    }
}
