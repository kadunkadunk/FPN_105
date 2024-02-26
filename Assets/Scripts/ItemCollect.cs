using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ItemCollect : MonoBehaviour 
{
    public Inventory inventory;
    public GameObject objectToInstantiate;
    public AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3))
        {
            Debug.Log(hit.transform.name);
            if (inventory != null)
            {
                Debug.Log("Inventory is not null");
                objectToInstantiate = inventory.inventoryItems.Find(x => x.name == "Hammer");
                if (objectToInstantiate != null)
                {
                    Debug.Log("Hammer found in inventory");
                    //audioSource.Play();
                    Instantiate(objectToInstantiate, hit.point, Quaternion.identity);
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
