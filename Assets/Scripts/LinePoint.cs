using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePoint : MonoBehaviour
{

    public LineRenderer line;
    void Start()
    {
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
        line.positionCount = 0;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 currentPoint = GetWorldCoordinate(Input.mousePosition);
            Debug.Log(currentPoint);
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, currentPoint);
        }
    }

    private Vector2 GetWorldCoordinate(Vector3 mousePosition)
    {
        Vector2 mousePoint = new Vector3(mousePosition.x, mousePosition.y, 1);
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
