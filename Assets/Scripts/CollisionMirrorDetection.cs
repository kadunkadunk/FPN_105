using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMirrorDetection : MonoBehaviour
{
    public Inventory inventory = null;
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Player")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            //Debug.Log("Test2");
            Debug.Log(collision.gameObject.name);
            Debug.Log(collision.contacts[0].thisCollider.gameObject.name);
            inventory = collision.gameObject.GetComponent<Inventory>();
            ParticleSystem ps = GameObject.Find("MirrorParticleSystem").GetComponent<ParticleSystem>();
            GameObject mirrorParent = GameObject.Find("MirrorParent");

            if (inventory.inventoryItems.Count > 0 && mirrorParent != null)
            {
                Debug.Log("Inventory is not null");
                //objectToInstantiate = inventory.inventoryItems.Find(x => x.name == "Hammer");
                //if (objectToInstantiate != null)
                //{
                    //Debug.Log("Hammer found in inventory");
                    //Instantiate(objectToInstantiate, collision.contacts[0].thisCollider.gameObject.transform.position, Quaternion.identity);
                //collision.contacts[0].thisCollider.GetComponent<AudioSource>().Play();
                ps.GetComponent<AudioSource>().Play();
                ps.Play();
                //gameObject.SetActive(false);// Destroy(gameObject);
                //GameObject mirror = GameObject.Find("Mirror");
                
                
                mirrorParent.SetActive(false);
                //mirror.SetActive(false);
                //}
            }
           
        }
    }
}
