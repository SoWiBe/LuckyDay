using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private List<GameObject> firesElements;
    [SerializeField] private List<GameObject> smokeElements;

    private bool _isFireOut;
    private int count = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isFireOut)
        {
            count++;

            if (count == 5)
            {
                Destroy(firesElements[0]);
                Destroy(firesElements[1]);
                Destroy(firesElements[5]);
                Destroy(smokeElements[0]);
                Destroy(smokeElements[1]);
                Destroy(smokeElements[5]);
            } else if (count ==10)
            {
                Destroy(firesElements[2]);
                Destroy(firesElements[3]);
                Destroy(firesElements[6]);
                Destroy(smokeElements[2]);
                Destroy(smokeElements[3]);
                Destroy(smokeElements[6]);
            } else if (count == 15)
            {
                Destroy(firesElements[4]);
                Destroy(firesElements[8]);
                Destroy(firesElements[7]);
                Destroy(smokeElements[4]);
            } else if (count == 20)
            {
                Destroy(smokeElements[7]);
                Destroy(smokeElements[8]);
                Destroy(smokeElements[9]);
                Destroy(firesElements[9]);
                Destroy(firesElements[10]);
                Destroy(firesElements[11]);
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pena"))
        {
            this._isFireOut = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pena"))
        {
            this._isFireOut = false;
        }
    }


}
