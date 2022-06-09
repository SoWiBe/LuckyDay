using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WaterManager : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private DialogueTrigger dialog;
    [SerializeField] private GameObject window;
    [SerializeField] private GameObject stacan;
    [SerializeField] private List<GameObject> firesElements;
    [SerializeField] private AudioSource audio;
    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(DoWhat());
        dialog.StartDialog();
        audio.Play();
    }

    IEnumerator DoWhat()
    {
        foreach (GameObject fire in firesElements)
        {
            fire.SetActive(true);
            yield return new WaitForSeconds(1.1f);
        }
        window.SetActive(true);
        gameObject.SetActive(false);
        stacan.SetActive(false);
    }
}
