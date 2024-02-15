using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController : MonoBehaviour
{
    public Animator doorAnim;

    private bool doorOpen = false;

    private void Awake()
    {
        //doorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            doorAnim.Play("CageOpen", 0, 0.0f);
            doorOpen = true;
        }
        else
        {
            doorAnim.Play("CageClose", 0, 0.0f);
            doorOpen = false;
        }
    }
    }
