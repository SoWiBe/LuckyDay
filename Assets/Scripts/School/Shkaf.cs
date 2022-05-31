using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shkaf : MonoBehaviour
{
    [SerializeField] private Animator _animShkaf;
    [SerializeField] private GameObject btnCloseShkaf;
    [SerializeField] private GameObject joystick;
    [SerializeField] private GameObject combination;
    [SerializeField] private GameObject locker;
    [SerializeField] private GameObject shkafOpen;
    



    public void OnMouseDown()
    {
        btnCloseShkaf.SetActive(true);
        if (locker.GetComponent<Locker>().ShkafOpen)
        {
            shkafOpen.SetActive(true);
            return;
        }
        _animShkaf.SetTrigger("isMoveShkaf");
        combination.SetActive(true);
        locker.SetActive(true);
        joystick.SetActive(false);
    }

    public void CloseShkaf()
    {
        _animShkaf.SetTrigger("isIdleShkaf");
        btnCloseShkaf.SetActive(false);
        combination.SetActive(false);
        locker.SetActive(false);
        shkafOpen.SetActive(false);
        joystick.SetActive(true);
    }

    public void SoCloseShkaf()
    {
        _animShkaf.SetTrigger("isCloseShkaf");
    }

}
