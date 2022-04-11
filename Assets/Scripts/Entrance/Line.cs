using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public bool IsEnd { get; set; }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndPoint"))
        {
            IsEnd = true;
            Debug.Log(IsEnd);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EndPoint"))
        {
            IsEnd = false;
            Debug.Log(IsEnd);
        }
    }
}
