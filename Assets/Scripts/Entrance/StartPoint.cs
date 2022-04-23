using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [SerializeField] private string color;
    public bool IsStartConnect { get; set; }
    private void Start()
    {
        IsStartConnect = false;
    }

    private void OnMouseDown()
    {
        Debug.Log("Alo");
        IsStartConnect = true;
    }
}
