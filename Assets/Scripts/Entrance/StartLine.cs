using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartLine : MonoBehaviour
{
    [SerializeField] private GameObject line;
    [SerializeField] private GameObject nextStep;
    [SerializeField] private LineScript lineScript;
    [SerializeField] private GameObject lastPoint;

    private LineRenderer lineRenderer;
    public bool IsConnect { get; set; }

    private void Start()
    {
        lineRenderer = line.GetComponent<LineRenderer>();
        IsConnect = false;
    }

    private void CheckPositionLine()
    {
        int lastPointX = (int)lastPoint.gameObject.transform.position.x;
        int lastPointY = (int)lastPoint.gameObject.transform.position.y;
        int linePointX = (int)lineRenderer.GetPosition(1).x;
        int linePointY = (int)lineRenderer.GetPosition(1).y;
        if (lastPointX == linePointX && lastPointY == linePointY)
        {
            if(nextStep != null)
            {
                IsConnect = true;
                nextStep.SetActive(true);
            } 
            else
            {
                IsConnect = true;
            }

        }
    }

    private void OnMouseDrag()
    {
        if (!IsConnect)
           lineScript.LastStep();
    }

    private void OnMouseUp()
    {
        if(!IsConnect)
        {
            lineScript.SecondStep();
            CheckPositionLine();
        }
        
    }

    private void OnMouseDown()
    {
        if(!IsConnect)
        {
            Debug.Log("sdfsd");
            line.SetActive(true);
            lineScript.FirstStep();
        }
    }
}
