using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewExit : MonoBehaviour
{
    [SerializeField] private GameObject screwExit;

    public void SetScrewActive()
    {
        screwExit.SetActive(true);
    }
}
