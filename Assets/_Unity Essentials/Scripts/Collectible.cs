using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject onCollectEffect;
    public float rotationSpeed = 0.5f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0f, rotationSpeed, 0f);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            //Destriy the collectible
            
            StarController.Instance.RemoveStar(gameObject);

            StarController.Instance.PlayStarCollectSound();

            Destroy(gameObject);

            
           

            //Instantiate the particle effect
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }

        



    }
}
