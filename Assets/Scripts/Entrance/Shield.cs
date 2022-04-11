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

    [SerializeField] PointControl[] pointControls;
    [SerializeField] private ConnectManager ConnectManager;
    private void OnMouseDown()
    {
        isOpenShield = !isOpenShield;
        canvasShield.SetActive(isOpenShield);
        SetStatusActiveObjects();
    }

    private void SetStatusActiveObjects()
    {
        inventory.SetActive(!isOpenShield);
        player.SetActive(!isOpenShield);
        joystick.SetActive(!isOpenShield);
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
