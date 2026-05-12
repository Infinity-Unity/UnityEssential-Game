using UnityEngine;


public class DoorOpener : MonoBehaviour
{
    private Animator doorAnimator;
    private AudioSource audioSource;
    [SerializeField] private AudioClip doorOpenSound;
    private bool doorOpen = false;



    void Start()
    {
        // Get the Animator component attached to the same GameObject as this script
        doorAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player (or another specified object)
        if (other.CompareTag("Player")) // Make sure the player GameObject has the tag "Player"
        {
            if (doorAnimator != null)
            {
                // Trigger the Door_Open animation
                doorAnimator.SetTrigger("Door_Open");
                if (!doorOpen)
                {
                    audioSource.PlayOneShot(doorOpenSound);
                    doorOpen = true;
                }
                
                
            }
        }
    }
}