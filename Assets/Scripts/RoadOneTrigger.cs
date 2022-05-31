using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadOneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneTransition.SwitchToScene("Entrance");
        }
    }
}
