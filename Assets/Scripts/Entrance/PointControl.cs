using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControl : MonoBehaviour
{
    [SerializeField] private GameObject firstPoint;
    [SerializeField] private GameObject lastPoint;
    [SerializeField] private LineRenderer line;
    [SerializeField] private StartPoint startPoint;
    
    private float alpha = 1.0f;

    public Color startColor = Color.yellow;
    public Color endColor = Color.yellow;

    private ScrewExit screwExit;
    public GameConnectLine connectLine;

    private void Start()
    {
        screwExit = gameObject.GetComponent<ScrewExit>();
        connectLine = gameObject.GetComponent<GameConnectLine>();
    }

    private void OnMouseDown() 
    { 
        if(startPoint.IsStartConnect)
        {
            line.SetPosition(0, new Vector3(firstPoint.transform.position.x, firstPoint.transform.position.y, 0));
            line.SetPosition(1, new Vector3(lastPoint.transform.position.x, lastPoint.transform.position.y, 0));
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(startColor, 0.0f), new GradientColorKey(endColor, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
            line.colorGradient = gradient;
            if (screwExit != null)
                screwExit.SetScrewActive();
            else
                connectLine.isConnected = true;
        }
        
    }

    public void ConnectLine()
    {
        if (startPoint.IsStartConnect)
        {
            line.SetPosition(0, new Vector3(firstPoint.transform.position.x, firstPoint.transform.position.y, 0));
            line.SetPosition(1, new Vector3(lastPoint.transform.position.x, lastPoint.transform.position.y, 0));
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(startColor, 0.0f), new GradientColorKey(endColor, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
            line.colorGradient = gradient;
        }
    }

    public void SetBasePositionLine()
    {
        line.SetPosition(0, new Vector3(0, 0, 0));
        line.SetPosition(1, new Vector3(0, 0, 0));
    }
}
