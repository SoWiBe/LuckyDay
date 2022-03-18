using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject closeDoor;
    [SerializeField] private GameObject doorImage;
    [SerializeField] private GameObject player;

    [SerializeField] private AudioSource soundDoorOpen;

    public bool _isOpen = false;
    private Animator _playerAnimator;

    public void OpenDoor()
    {
        closeDoor.SetActive(_isOpen);
        _isOpen = !_isOpen;
        Debug.Log(_isOpen);
        doorImage.SetActive(_isOpen);
        soundDoorOpen.Play();
    }
    private void OnMouseDown()
    {
        OpenDoor();
    }
}
