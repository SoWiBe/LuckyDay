using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private DialogMessage firstDialog;
    [SerializeField] private GameObject dialogWindow;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log("Вошел в зону");
            dialogWindow.SetActive(true);
            firstDialog.StartDialog();
            Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>());
        }
    }
}
