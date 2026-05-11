using UnityEngine;

public class BallTeleport : MonoBehaviour
{

    private Vector3 pos;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos = transform.position;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
            
            transform.position = pos;
            rb.velocity = Vector3.zero;            
        }
      
    }
}
