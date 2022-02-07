using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] senteces;
    private int index;
    public float typingSpeed;

    public void StartDialog()
    {
        StartCoroutine(Type());
    }
    
    IEnumerator Type()
    {
        foreach (char letter in senteces[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

}
