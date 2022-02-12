using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersDialogs : MonoBehaviour
{
    [SerializeField] private DialogMessage firstDialog;
    [SerializeField] private GameObject dialogWindow;
    

    private Animator animator;
    
    private void Start()
    {
        animator = dialogWindow.GetComponent<Animator>();
        dialogWindow.SetActive(false);
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.TryGetComponent(out Player player))
        {
            dialogWindow.SetActive(true);
            animator.SetBool("isVisible", true);
            firstDialog.StartDialog();
            Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>());
        }
    }
}
