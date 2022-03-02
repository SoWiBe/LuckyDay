using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    private Animator animatorDialog;
    private bool _isOpen = false;

    private void Start()
    {
        animatorDialog = gameObject.GetComponent<Animator>();
    }

    public void OpenDialogWindow()
    {
        this._isOpen = !_isOpen;
        animatorDialog.SetBool("_isOpenDialog", this._isOpen);
    }
}
