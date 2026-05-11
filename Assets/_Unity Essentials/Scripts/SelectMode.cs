using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMode : MonoBehaviour
{

    [SerializeField] private Button roomsButton;
    [SerializeField] private Button galleryButton;
    [SerializeField] private Button otherButton;
    [SerializeField] private Button closeOpenMenuButton;

    [SerializeField] private GameObject selectPanel;
    [SerializeField] private GameObject rooms;
    [SerializeField] private GameObject gallery;
    [SerializeField] private GameObject other;

    [SerializeField] private GameObject player;
    


    void Start()
    {
        
        roomsButton.onClick.AddListener(TurnRoomsPrefab);
        galleryButton.onClick.AddListener(TurnGalleryPrefab);
        otherButton.onClick.AddListener(TurnOtherPrefab);
        closeOpenMenuButton.onClick.AddListener(OpenClosePanel);
    }

    void Update()
    {
        
    }

    private void TurnRoomsPrefab()
    {
        player.SetActive(true);
        selectPanel.SetActive(false);
        rooms.SetActive(true);
        gallery.SetActive(false);
        other.SetActive(false);
    }

    private void TurnGalleryPrefab()
    {
        player.SetActive(false);

        selectPanel.SetActive(false);
        rooms.SetActive(false);
        gallery.SetActive(true);
        other.SetActive(false);
    }

    private void TurnOtherPrefab()
    {
        player.SetActive(false);
        selectPanel.SetActive(false);
        rooms.SetActive(false);
        gallery.SetActive(false);
        other.SetActive(true);
    }

    private void OpenClosePanel()
    {
        if (selectPanel.activeSelf)
        {
            selectPanel.SetActive (false);
        }
        else
        {
            selectPanel.SetActive (true);
        }
    }

}
