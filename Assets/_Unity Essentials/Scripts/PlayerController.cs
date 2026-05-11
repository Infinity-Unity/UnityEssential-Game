using UnityEngine;
using UnityEngine.InputSystem;

// Controls player movement and rotation.
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; 
    public float jumpForce = 5.0f; 
    public float rotationSpeed = 120.0f; 

    private Rigidbody rb; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log(transform.rotation.y);
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0,transform.eulerAngles.y,0));
        }
    }


    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = moveVertical * speed * Time.fixedDeltaTime * transform.forward;
        //Debug.Log($"moveVertical: {moveVertical}. fixedDeltaTime: {Time.fixedDeltaTime}. Movement: {movement}.");
        rb.MovePosition(rb.position + movement);

        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}