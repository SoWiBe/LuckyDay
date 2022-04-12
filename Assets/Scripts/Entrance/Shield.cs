using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private bool isOpenShield = false;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject joystick;
    [SerializeField] private GameObject canvasShield;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject chest;

    [SerializeField] private Pickup[] inventoryItems;
    [SerializeField] private DialogueTrigger dialogueTrigger;

    [SerializeField] PointControl[] pointControls;
    [SerializeField] private ConnectManager ConnectManager;

    private void OnMouseDown()
    {
        if (!inventoryItems[0].isTaked)
        {
            dialogueTrigger.StartDialog();
            return;
        }

        if (ConnectManager.isGame)
        {
            isOpenShield = !isOpenShield;
            canvasShield.SetActive(true);
            SetStatusActiveObjects();
        }
    }

    private void SetStatusActiveObjects()
    {
        inventory.SetActive(!isOpenShield);
        player.SetActive(!isOpenShield);
        joystick.SetActive(!isOpenShield);
        chest.SetActive(!isOpenShield);
    }

    public void CloseShield()
    {
        for (int i = 0; i < pointControls.Length; i++)
        {
            pointControls[i].SetBasePositionLine();
        }
        isOpenShield = !isOpenShield;
        canvasShield.SetActive(isOpenShield);
        SetStatusActiveObjects();
    }
}
