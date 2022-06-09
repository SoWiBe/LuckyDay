using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetrad : MonoBehaviour
{
    [SerializeField] private GameObject tetrad;
    public void TakeTetrad()
    {
        tetrad.SetActive(false);
    }
}
