using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowProlog : MonoBehaviour
{
    [SerializeField] private GameObject windowOpen;
    [SerializeField] private DialogueTrigger dialog;
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private List<GameObject> firesElements;
    [SerializeField] private AudioSource audio;

    public void OnMouseDown()
    {
        windowOpen.SetActive(true);
        StartCoroutine(DoWhat());
        dialog.StartDialog();
        box.enabled = true;
        audio.Play();
    }

    IEnumerator DoWhat()
    {
        foreach (GameObject fire in firesElements)
        {
            fire.SetActive(true);
            yield return new WaitForSeconds(1.1f);
        }
    }
}
