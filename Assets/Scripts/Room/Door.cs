using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject closeDoor;
    [SerializeField] private GameObject doorImage;

    [SerializeField] private AudioSource soundDoorOpen;

    public bool _isOpen = false;

    public void OpenDoor()
    {
        closeDoor.SetActive(_isOpen);
        _isOpen = !_isOpen;
        doorImage.SetActive(_isOpen);
        soundDoorOpen.Play();
    }
    private void OnMouseDown()
    {
        Debug.Log(1);
        OpenDoor();
    }
}
