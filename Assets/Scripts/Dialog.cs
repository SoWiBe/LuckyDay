using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private string[] senteces;
    [SerializeField] private float typingSpeed;

    private int index;
   
    public void StartDialog()
    {
        StartCoroutine(Type());
    }
    
    IEnumerator Type()
    {
        for(int i = 0; i < senteces[index].ToCharArray().Length; i++)
        {
            textDisplay.text += senteces[index][i];

            if(i == senteces[index].ToCharArray().Length - 1)
            {

            }
            yield return new WaitForSeconds(typingSpeed);
        }
        NextSentence();
    }

    public void NextSentence()
    {
        if(index < senteces.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
    }

}
