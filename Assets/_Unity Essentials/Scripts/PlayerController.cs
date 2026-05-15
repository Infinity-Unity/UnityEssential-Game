using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float jumpForce = 5.0f;
    [SerializeField] float rotationSpeed = 120.0f;

   
    [SerializeField] private ParticleSystem onWinEffect;
    bool isPlayWinEffect = false;
    //[SerializeField] private Camera camera;

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
        

        if ((StarController.Instance?.GetStarCount() == 0 && !isPlayWinEffect) || Input.GetKeyDown(KeyCode.B))
        {
            onWinEffect.Play();
            isPlayWinEffect = true;
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