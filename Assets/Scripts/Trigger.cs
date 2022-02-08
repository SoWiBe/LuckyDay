using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private Dialog firstDialog;
    public GameObject dialogWindow;
    public GameObject videoPlayer;
    public int timeToStop;
    private void Start()
    {
        //videoPlayer.SetActive(true);
        dialogWindow.SetActive(false);
        Destroy(videoPlayer, timeToStop);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log("Вошел в зону");
            dialogWindow.SetActive(true);
            firstDialog.StartDialog();
            Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>());
        }
    }
}
