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

    private bool isMoving = false;

    public void OnMouseDown()
    {
        if (isMoving)
            return;
        isMoving = true;
        animator.SetTrigger("isTableOpen");
        joystick.SetActive(false);
        dialogWindow.SetActive(false);
        StartCoroutine(SetActiveMain());
    }

    IEnumerator SetActiveMain()
    {
        yield return new WaitForSeconds(0.35f);
        btnClose.SetActive(true);
        mainKontrolnaja.SetActive(true);
    }
    public void CloseTetrad()
    {
        isMoving = false;
        animator.SetTrigger("isTableClose");
        joystick.SetActive(true);
        dialogWindow.SetActive(true);
        btnClose.SetActive(false);
        mainKontrolnaja.SetActive(false);
    }
}
