using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject onCollectEffect;
    public float rotationSpeed = 0.5f;
    public int score = 0;

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
            Destroy(gameObject);

            //add player score
            score++;

            //Instantiate the particle effect
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }

        



    }
}
