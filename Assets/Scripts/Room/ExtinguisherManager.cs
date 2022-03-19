using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExtinguisherManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Player player;
    public void OnPointerDown(PointerEventData eventData)
    {
        player.OutFire();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.StopPena();
    }
}
