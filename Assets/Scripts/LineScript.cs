using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    public Transform sphere1;
    public Transform sphere2;
    private bool isLineCreating = false;
    private Vector3 PointOnePos;
    public Camera camera;
    LineRenderer line;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 4;
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            Physics.Raycast(ray, out raycastHit);
            Debug.LogWarning(raycastHit.point);

            Debug.LogWarning("FirstIf");
            switch (raycastHit.transform.name)
            {
                case "PointOne":
                    isLineCreating = true;
                    PointOnePos = raycastHit.transform.position;
                    Debug.LogWarning("PointOne");

                    break;
                case "PointSecond":
                    if (isLineCreating)
                    {
                        line.SetPosition(0, PointOnePos);
                        line.SetPosition(1, raycastHit.transform.position);
                        isLineCreating = false;
                    }
                    Debug.LogWarning("PointSecond");

                    break;
            }

        }
        
    }
}
