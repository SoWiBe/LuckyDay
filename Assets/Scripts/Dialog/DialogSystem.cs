using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    private Animator animatorDialog;
    private bool _isOpen = false;
    private string sentencePre;

    [SerializeField] private Text dialogueTextPre;
    [SerializeField] private Text dialogueText;
    [SerializeField] private GameObject dialogueWindow;

    private Queue<string> sentences;

    private void Start()
    {
        animatorDialog = dialogueWindow.GetComponent<Animator>();
        sentences = new Queue<string>();
    }

    private void Update()
    {
        SetTextAnimation();
    }

    public void OpenDialogWindow()
    {
        this._isOpen = !_isOpen;
        animatorDialog.SetBool("_isOpenDialog", this._isOpen);
    }

    public void StartDialogue (Dialog dialog)
    {
        OpenDialogWindow();
        sentences.Clear();

        foreach(string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        StartCoroutine(DoSentence());
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        if(sentencePre != "")
        {
            dialogueTextPre.text = sentencePre;
        }
        sentencePre = sentence;
        
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator DoSentence()
    {
        for (int i = 0; i < 5; i++)
        {
            DisplayNextSentence();
            yield return new WaitForSeconds(4f);
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue() { }

    private void SetTextAnimation()
    {
        if(animatorDialog.GetCurrentAnimatorStateInfo(0).IsName("stay_dialog"))
        {
            
        }
    }
}
