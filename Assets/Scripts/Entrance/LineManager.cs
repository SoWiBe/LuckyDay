using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField] private GameObject firstLine;
    [SerializeField] private GameObject secondLine;

    private bool CheckActiveStatusForLines()
    {
        if (!firstLine.activeSelf && !secondLine.activeSelf)
            return true;
        else if (firstLine.activeSelf && !secondLine.activeSelf)
            return false;
        else
            return false;
    }

    public void SetActiveFirst()
    {
        firstLine.SetActive(true);
    }

    public void SetActiveSecond()
    {
        secondLine.SetActive(true);
    }
}
