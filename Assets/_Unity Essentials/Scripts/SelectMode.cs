using UnityEngine;
using UnityEngine.UI;

public class SelectMode : MonoBehaviour
{

    [SerializeField] private Button roomsButton;
    [SerializeField] private Button galleryButton;
    [SerializeField] private Button otherButton;
    [SerializeField] private Button closeOpenMenuButton;

    [SerializeField] private GameObject selectPanel;
    [SerializeField] private GameObject roomsHouse;
    [SerializeField] private GameObject gallery;
    //[SerializeField] private GameObject other; // когда нибудь что то добавлю

    [SerializeField] private GameObject player;

    private GameObject currentRoom;
    


    void Start()
    {    
        roomsButton.onClick.AddListener(() => ShowRoom(roomsHouse));
        galleryButton.onClick.AddListener(() => ShowRoom(gallery));
        //otherButton.onClick.AddListener(() => ShowRoom(other));
        closeOpenMenuButton.onClick.AddListener(OpenClosePanel);
    }

    


    private void OpenClosePanel()
    {
        selectPanel.SetActive(!selectPanel.activeSelf);
    }

    private void ShowRoom(GameObject room)
    {
        if (room == null) return;
        if(currentRoom == room) return;

        if(currentRoom != null)
        {
            currentRoom.SetActive(false);
        }

        if(room == roomsHouse) player.SetActive(true);
        else player.SetActive(false);

        room.SetActive(true);
        selectPanel.SetActive(false);
        currentRoom = room;

        


    }

}
