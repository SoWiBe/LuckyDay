using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI txtComb;
    [SerializeField] private GameObject shkafOpen;
    [SerializeField] private Animator shkafAnimator;
    [SerializeField] private DialogueTrigger dialogue;
    [SerializeField] private Animator incorrectVisible;
    [SerializeField] private GameObject btnClose;
    [SerializeField] private GameObject triggerToFight;

    public bool ShkafOpen { get; set; }

    private string correctCombination = "8419";
    private int clear = 0;
    public void WriteCode(int id)
    {
        txtComb.text += id;
        clear++;

        if (clear == 4)
        {
            CheckResult(txtComb.text);
            clear = 0;
            txtComb.text = "";
        }
    }

    private void CheckResult(string combination)
    {
        if(combination.Equals(correctCombination))
        {
            shkafAnimator.SetTrigger("isIdleShkaf");
            shkafOpen.SetActive(true);
            dialogue.StartDialog();
            btnClose.SetActive(true);
            ShkafOpen = true;
            triggerToFight.SetActive(true);
        }
        else
        {
            incorrectVisible.SetTrigger("lockerError");
        }
    }
}
