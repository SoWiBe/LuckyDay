using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    [SerializeField] private GameObject shieldObj;
    private Shield shield;

    private void Start()
    {
        shield = shieldObj.GetComponent<Shield>();
    }
    public void CloseShield()
    {
        for (int i = 0; i < shield.pointControls.Length; i++)
        {
            shield.pointControls[i].SetBasePositionLine();
        }
        shield.isOpenShield = !shield.isOpenShield;
        shield.canvasShield.SetActive(shield.isOpenShield);
        shield.SetStatusActiveObjects();
        shieldObj.SetActive(true);
    }
}
