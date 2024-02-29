using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(AudioSource))]
public class ItemCollect : MonoBehaviour 
{
    public Inventory inventory;
    public AudioSource audioSource;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
     void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse down event");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 3))
            {
                player = GameObject.FindWithTag("Player");
                inventory = player.GetComponent<Inventory>();
                GameObject paperclip = inventory.inventoryItems.Find(x => x.name == "Paperclip");
                Debug.Log("Paperclip found in inventory: " + paperclip);

                Debug.Log(hit.transform.name);
                if (inventory != null)
                {
                    Debug.Log("Inventory is not null");
                    if (paperclip != null)
                    {
                        Debug.Log("Paperclip created");
                        //audioSource.Play();
                        Instantiate(paperclip, hit.point, Quaternion.identity);
                        paperclip.SetActive(true);
                    }
                }
                else
                {
                    Debug.Log("Inventory is null");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventory = other.GetComponent<Inventory>();
            inventory.addToInventory(gameObject); // this is the whole game object 'w'.
            //Instantiate(objectToInstantiate, gameObject.transform.position, Quaternion.identity);

            gameObject.SetActive(false);// Destroy(gameObject);
            
        } else 
        {
            Debug.Log("Not a player");
            Debug.Log(other.tag);
        }
    }
}
