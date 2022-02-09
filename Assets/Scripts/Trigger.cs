using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private Dialog firstDialog;
    [SerializeField] private GameObject dialogWindow;
    [SerializeField] private GameObject videoPlayer;
    [SerializeField] private int timeToStop;

    private Animator animator;
    
    private void Start()
    {
        //this for first start in game, needs to check this and play in dependence result
        //videoPlayer.SetActive(true);
        //Destroy(videoPlayer, timeToStop);
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
