using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    public LineRenderer line;
    private Vector3 mousePos;
    public Material material;
    private int currLine = 0;

    public void FirstStep()
    {
        if (line == null)
        {
            createLine();
        }
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        line.SetPosition(0, mousePos);
        line.SetPosition(1, mousePos);
    }


    public void SecondStep()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        line.SetPosition(1, mousePos);
        currLine++;
    }

    public void LastStep()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        line.SetPosition(1, mousePos);
    }
    public void createLine()
    {
        line.positionCount = 2;
        line.startWidth = 0.15f;
        line.endWidth = 0.15f;
        line.useWorldSpace = false;
        line.numCapVertices = 50;
    }
}