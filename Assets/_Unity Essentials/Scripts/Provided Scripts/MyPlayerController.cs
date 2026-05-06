using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour
{
    public float speed = 5f;
    public bool canMoveDiagonally = false;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isMovingHorizontally = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }


    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");


        /*if (verticalInput != 0)
        {
            isMovingHorizontally = false;
        }
        else if (horizontalInput != 0)
        {
            isMovingHorizontally = true;
        }

        if (isMovingHorizontally)
        {
            movement = new Vector2(horizontalInput, 0);
            RotatePlayer(horizontalInput, 0);
        }
        else
        {
            movement = new Vector2(0, verticalInput);
            RotatePlayer(0,verticalInput);
        }*/

        movement = new Vector2(horizontalInput, verticalInput);
        RotatePlayer(horizontalInput,verticalInput);

        
        
    }


    private void FixedUpdate()
    {
        rb.velocity = movement * speed;
        Debug.Log($"Veloctiy({rb.velocity}) = movement({movement}) * speed({speed})");
    }

    void RotatePlayer(float x, float y)
    {
        // If there is no input, do not rotate the player
        if (x == 0 && y == 0) return;

        // Calculate the rotation angle based on input direction
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        // Apply the rotation to the player
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}
