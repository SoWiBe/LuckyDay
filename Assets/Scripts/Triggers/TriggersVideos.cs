using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersVideos : MonoBehaviour
{
    [SerializeField] private GameObject videoPlayer;
    [SerializeField] private int timeToStop;

    private void Start()
    {
        //this for first start in game, needs to check this and play in dependence result
        //videoPlayer.SetActive(true);
        //Destroy(videoPlayer, timeToStop);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Player player))
        {
            videoPlayer.SetActive(true);
            Destroy(videoPlayer, timeToStop);
            Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>());
        }
    }
}
