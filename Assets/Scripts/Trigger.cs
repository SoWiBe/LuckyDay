using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private Dialog firstDialog;
    public GameObject videoPlayer;
    public int timeToStop;
    private void Start()
    {
        videoPlayer.SetActive(true);
        Destroy(videoPlayer, timeToStop);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log("Вошел в зону");
            firstDialog.StartDialog();
        }

    }
}
