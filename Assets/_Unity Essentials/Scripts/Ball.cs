using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
     private AudioSource audioSource;
    [SerializeField] private AudioClip ballSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(ballSound);
    }
}
