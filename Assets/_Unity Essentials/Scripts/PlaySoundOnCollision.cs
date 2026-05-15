using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip sound;

    void Awake()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(sound);
    }
}
