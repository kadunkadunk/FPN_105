using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDirtDetection : MonoBehaviour
{
    public Inventory inventory;
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
        {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Player")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            //Debug.Log("Test2");
            inventory = collision.gameObject.GetComponent<Inventory>();
            ParticleSystem ps = GameObject.Find("DirtParticleSystem").GetComponent<ParticleSystem>();
            Debug.Log(collision.gameObject.name);
            Debug.Log(collision.contacts[0].thisCollider.gameObject.name);
            GameObject wall = GameObject.Find("DirtWallCube");
            if ((inventory.useTool.name == "Shovel") && wall != null)
            {
                
                ps.Play();
                //gameObject.SetActive(false);// Destroy(gameObject);
                
                wall.SetActive(false);
            }
           
        }
        
        }
    
}
