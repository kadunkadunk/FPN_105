using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWhyMe : MonoBehaviour
{
    private AudioSource _audioSource;
   
   public void PlayWhyMeSound()
    {
       Debug.Log("Why me sound played");
       _audioSource = this.GetComponent<AudioSource>();
       _audioSource.Play();
            
    }
}
