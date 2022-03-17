using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject closeDoor;
    [SerializeField] private GameObject doorImage;
    [SerializeField] private GameObject player;

    [SerializeField] private AudioSource soundDoorOpen;

    private bool _isOpen = false;
    private Animator _playerAnimator;

    public void OpenDoor()
    {
        this._isOpen = !_isOpen;
        closeDoor.SetActive(!_isOpen);
        doorImage.SetActive(this._isOpen);
        soundDoorOpen.Play();
    }
}
