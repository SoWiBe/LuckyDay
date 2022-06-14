using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private Animator anim_car;
    [SerializeField] private DialogueTrigger dialogue;
    [SerializeField] private GameObject button_left;
    [SerializeField] private GameObject button_right;
    [SerializeField] private Animator anim_car_front;
    private int flag = 0;

    private bool isRight, isLeft;

    private void Start()
    {
        if(anim_car_front != null)
            anim_car_front.SetTrigger("isMoveCarOne");
        GoCar();
    }

    public void SetNextStep()
    {
        anim_car.SetTrigger("cardGoTwo");
    }

    private void GoCar()
    {
        anim_car.SetTrigger("Move");
    }

    public void SetRight()
    {
        CheckRightAndLeft();
        button_right.SetActive(false);
    }

    public void SetLeft()
    {
        CheckRightAndLeft();
        button_left.SetActive(false);
    }

    private void CheckRightAndLeft()
    {
        if (dialogue != null)
        {
            dialogue.StartDialog();
            if(anim_car_front != null)
                anim_car_front.SetTrigger("isMoveCarTwo");
        }
            
    }
}
