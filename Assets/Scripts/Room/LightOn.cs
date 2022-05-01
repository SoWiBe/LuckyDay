using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour
{
    [SerializeField] private DialogueTrigger dialogue;
    [SerializeField] private AudioSource audio;
    private Action action; 
    private int countClicks = 0;

    private void Start()
    {
        action = StartDialog;
    }
    private void OnMouseDown()
    {
        countClicks++;
        audio.Play();
        if(countClicks > 2)
        {
            action.Invoke();
            action = End;
        }
    }

    private void StartDialog()
    {
        dialogue.StartDialog();
    }
    private void End()
    {

    }
}
