using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private GameObject joystick;
    [SerializeField] private GameObject dialogWindow;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject btnClose;
    [SerializeField] private GameObject mainKontrolnaja;

    public void OnMouseDown()
    {
        animator.SetTrigger("isTableOpen");
        joystick.SetActive(false);
        dialogWindow.SetActive(false);
        btnClose.SetActive(true);
        mainKontrolnaja.SetActive(true);
    }

    public void CloseTetrad()
    {
        animator.SetTrigger("isTableClose");
        joystick.SetActive(true);
        dialogWindow.SetActive(true);
        btnClose.SetActive(false);
        mainKontrolnaja.SetActive(false);
    }
}
