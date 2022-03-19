using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] private Player player;

    private void OnMouseDown()
    {
        player.GetExtinguisher();
    }
}
