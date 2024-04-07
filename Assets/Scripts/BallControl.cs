using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float speed = 5.0f;
    bool canMove = true;
    public float limitLeft = -12.25f;
    public float limitRight = 12.25f;
    public float resetPosition = 7.0f;
    
    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            Vector3 moveOffset = Vector3.zero;
            moveOffset.x = Input.GetAxis("Horizontal");
            moveOffset.x = moveOffset.x * speed * Time.deltaTime;
            Vector3 newPosition = transform.position + moveOffset;
            if(newPosition.x > limitRight)
            {
                newPosition.x = limitRight;
            }
            if (newPosition.x < limitLeft)
            {
                newPosition.x = limitLeft;
            }
            transform.position = newPosition;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                canMove = false;
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().AddForce(Random.Range(-5f,5f),0,0,ForceMode.Impulse);
                
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bottom")
        {
            canMove = true;
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = new Vector3(0, resetPosition, 0);
        }
    }
}
