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
            SetActiveMessage();
            Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>());
        }
    }

    public void SetInnactiveMessage()
    {
        animator.SetBool("isEnableHelpMessage", false);
    }
    public void SetActiveMessage()
    {
        dialogWindow.SetActive(true);
        animator.SetBool("isEnableHelpMessage", true);
        firstDialog.StartDialog();
    }
}
