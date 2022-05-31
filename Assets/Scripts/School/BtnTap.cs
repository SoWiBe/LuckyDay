using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnTap : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int Number;
    [SerializeField] private Locker locker;
    public void Tap()
    {
        animator.SetTrigger("isTapCode");
        locker.WriteCode(Number);
    }
}
