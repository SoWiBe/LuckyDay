using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersHelpManager : MonoBehaviour
{
    [SerializeField] private HelpMessage firstDialog;
    [SerializeField] private GameObject dialogWindow;

    private Animator animator;

    private void Start()
    {
        animator = dialogWindow.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Player player))
        {
            dialogWindow.SetActive(true);
            //animator.SetBool("isVisible", true);
            firstDialog.StartDialog();
            Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>());
        }
    }

}
