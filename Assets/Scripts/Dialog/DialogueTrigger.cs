using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialog dialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartDialog();
        }
    }

    public void StartDialog()
    {
        FindObjectOfType<DialogSystem>().StartDialogue(dialog);
        Destroy(gameObject);
    }
}
