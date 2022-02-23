using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    public LineRenderer line;
    [SerializeField]
    GameObject sphere1;
    [SerializeField]
    GameObject sphere2;
    float x, y;
    private void Start()
    {
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.positionCount = 0;
        x = sphere1.transform.position.x;
        y = sphere1.transform.position.y;
    }
    private void Update()
    {
        float x1 = Input.mousePosition.x;
        float y1 = Input.mousePosition.y;
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 currentPoint = GetWorldCoordinate(Input.mousePosition);

            Debug.Log(x);
            Debug.Log(x);
            if (x1 == x)
            {
                line.positionCount++;
                line.SetPosition(line.positionCount - 1, currentPoint);
            }

        }

    }

    private Vector2 GetWorldCoordinate(Vector3 mousePosition)
    {
        Vector2 mousePoint = new Vector3(mousePosition.x, mousePosition.y, 1);
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 currentPoint = GetWorldCoordinate(Input.mousePosition);
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, currentPoint);
        }

    }

}