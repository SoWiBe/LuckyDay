using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] private Player player;

    private void OnMouseDown()
    {
        player.GetExtinguisher();
    }
}
