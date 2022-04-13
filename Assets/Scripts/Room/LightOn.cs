using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour
{
    [SerializeField] private DialogueTrigger dialogue;
    [SerializeField] private AudioSource audio;
    private int countClicks = 0;
    private void OnMouseDown()
    {
        countClicks++;
        audio.Play();
        if(countClicks > 2)
        {
            dialogue.StartDialog();
        }
    }
}
