using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMirrorDetection : MonoBehaviour
{
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
            ParticleSystem particleSystem = collision.contacts[0].thisCollider.gameObject.GetComponent<ParticleSystem>();
            particleSystem.Play();
        }
    }
}
