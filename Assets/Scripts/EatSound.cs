using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatSound : MonoBehaviour
{
    public AudioClip eatSound;
    private AudioSource audioSource;

    private void Start() {
        audioSource.clip = eatSound;
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Food")
        {
            audioSource.Play();
        }    
    }
}
