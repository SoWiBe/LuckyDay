using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class Shkaf : MonoBehaviour
{
    [SerializeField] private Animator _animShkaf;
    [SerializeField] private GameObject btnCloseShkaf;
    [SerializeField] private GameObject joystick;
    [SerializeField] private GameObject combination;
    [SerializeField] private GameObject locker;
    [SerializeField] private GameObject shkafOpen;
    [SerializeField] private GameObject dialogWindow;
    [SerializeField] private GameObject text;
    [SerializeField] private VideoPlayer video;

    private bool isMoving = false;



    public void OnMouseDown()
    {
        if (isMoving)
            return;

        isMoving = true;
        joystick.SetActive(false);
        dialogWindow.SetActive(false);
        text.SetActive(false);
        btnCloseShkaf.SetActive(true);
        if (locker.GetComponent<Locker>().ShkafOpen)
        {
            shkafOpen.SetActive(true);
            return;
        }
        StartCoroutine(StartVideo());

    }

    IEnumerator StartVideo()
    {
        video.Play();
        yield return new WaitForSeconds(6.2f);
        video.Stop();
        _animShkaf.SetTrigger("isMoveShkaf");
        
        StartCoroutine(SetActiveMain());
    }
    IEnumerator SetActiveMain()
    {
        yield return new WaitForSeconds(0.35f);
        
        combination.SetActive(true);
        locker.SetActive(true);
        
    }
    public void CloseShkaf()
    {
        isMoving = false;
        _animShkaf.SetTrigger("isIdleShkaf");
        video.Stop();
        btnCloseShkaf.SetActive(false);
        combination.SetActive(false);
        locker.SetActive(false);
        shkafOpen.SetActive(false);
        joystick.SetActive(true);
        dialogWindow.SetActive(true);
        text.SetActive(true);
    }

    public void SoCloseShkaf()
    {
        _animShkaf.SetTrigger("isCloseShkaf");
    }

}
