using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private Animator anim_car;
    [SerializeField] private DialogueTrigger dialogue;
    private int flag = 0;

    private bool isRight, isLeft;

    private void Start()
    {
        GoCar();
    }

    public void SetNextStep()
    {
        anim_car.SetTrigger("cardGoTwo");
    }

    private void GoCar()
    {
        anim_car.SetTrigger("carGo");
    }

    public void SetRight()
    {
        isRight = true;
        CheckRightAndLeft();
    }

    public void SetLeft()
    {
        isLeft = true;
        CheckRightAndLeft();

    }

    private void CheckRightAndLeft()
    {
        if (isRight && isLeft) dialogue.StartDialog();
    }
}
