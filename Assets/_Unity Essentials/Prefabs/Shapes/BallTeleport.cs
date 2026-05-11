using UnityEngine;

public class BallTeleport : MonoBehaviour
{

    private Transform ball;
    private Vector3 pos;
    private Rigidbody rb;

    void Start()
    {
        ball = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        pos = transform.position;
        /*Debug.Log($"Начальная позиция шара: {pos}.");*/
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
            
            transform.position = pos;
            rb.velocity = new Vector3(0f, 0f, 0f);            
        }
        /*Debug.Log($"Текущая позиция шара: {pos}.");
        Debug.Log($"Скорость шара(вектор): {rb.velocity}");
        Debug.Log($"Скорость шара(число): {rb.velocity.magnitude}");*/

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity += new Vector3(0f,0f,0.1f);
        }
    }
}
