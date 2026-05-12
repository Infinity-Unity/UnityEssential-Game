using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float jumpForce = 5.0f;
    [SerializeField] float rotationSpeed = 120.0f;

    [SerializeField] private GameObject onWinEffect;
    [SerializeField] private Camera camera;

    private Rigidbody rb; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        

        if (Input.GetKey(KeyCode.R))
        {
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0,transform.eulerAngles.y,0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
        }
        if(StarController.Instance != null && StarController.Instance.GetStarCount() == 0)
        {
            Instantiate(onWinEffect, transform.position, transform.rotation);
        }

        if (Input.GetKey(KeyCode.B))
        {
            Instantiate(onWinEffect, camera.transform.position, camera.transform.rotation);
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