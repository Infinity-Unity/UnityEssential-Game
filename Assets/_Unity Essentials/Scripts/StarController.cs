using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarController : MonoBehaviour
{
    private List<GameObject> stars = new List<GameObject>();
    public static StarController Instance;
    private AudioSource audioSource;
    [SerializeField] private Text messageText;
    [SerializeField] AudioClip starCollectSound;
    [SerializeField] private AudioClip winSound;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {  
        messageText.text = $"Stars remaining: {stars.Count}";
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void RegisterStar(GameObject star)
    {
        stars.Add(star);
        UpdateText();
        CheckAllStarsCollected();

    }

    public void RemoveStar(GameObject star)
    {
        stars.Remove(star);
        UpdateText();
        CheckAllStarsCollected();
    }

    private void UpdateText()
    {
        messageText.text = "Score: " + stars.Count.ToString();
    }

    private void CheckAllStarsCollected()
    {
        if(stars.Count == 0)
        {
            messageText.text = "You collect all stars";
            audioSource.PlayOneShot(winSound);
        }
    }

    public void PlayStarCollectSound()
    {
        audioSource.PlayOneShot(starCollectSound);
    }

    
}
