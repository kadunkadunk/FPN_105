using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 5.0f;
    // Update is called once per frame
    void Update()
    {
        Vector3 shipOffset = Vector3.zero;
        shipOffset.x = Input.GetAxis("Horizontal");
        shipOffset.z = Input.GetAxis("Vertical");  
        shipOffset = shipOffset.normalized * speed * Time.deltaTime;

        transform.position = transform.position + shipOffset;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Debug.Log("You Lose!");
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("You Win!");
        Destroy(this.gameObject);
     
    }
}
