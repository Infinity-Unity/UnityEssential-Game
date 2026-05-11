using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip blockSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(blockSound);
    }
}
