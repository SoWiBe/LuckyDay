using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogMessage : MonoBehaviour
{
    [SerializeField] private Text textDisplay;
    [SerializeField] private string[] senteces;
    [SerializeField] private float typingSpeed;

    private int index = 0;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void StartDialog()
    {
        StartCoroutine(Type());
    }
    
    IEnumerator Type()
    {
        for(int i = 0; i < senteces[index].ToCharArray().Length; i++)
        {
            textDisplay.text += senteces[index][i];
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(index < senteces.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }

        Debug.Log("Content");
    }


    public void CloseDialogWindow()
    {
        if (index == senteces.Length - 1)
            animator.SetBool("isVisible", false);
        NextSentence();
    }

}
