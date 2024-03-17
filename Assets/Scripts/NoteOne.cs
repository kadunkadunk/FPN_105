using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteOne : MonoBehaviour
{
    public AudioSource audiosource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audiosource = GetComponent<AudioSource>();
            audiosource.Play();
        }
    }
}
