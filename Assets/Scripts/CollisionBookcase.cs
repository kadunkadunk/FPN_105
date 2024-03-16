using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBookcase : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Player")
        {
            //if (Input.GetKeyDown(KeyCode.UpArrow))
            //{ 
                Debug.Log("Collision with bookcase");
                transform.position = new Vector3(0, 0, 3);

            //}
        }
    }
 }
