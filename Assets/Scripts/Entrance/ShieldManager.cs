using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    [SerializeField] private GameObject shieldObj;
    [SerializeField] private GameObject canvasShield;
    private Shield shield;

    private void Start()
    {
        shield = shieldObj.GetComponent<Shield>();
    }
}
