using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProlog : MonoBehaviour
{
    
    [SerializeField] private Transform holdPoint;
    [SerializeField] private GameObject btnUse;
    
    private Action updatePosition;

    private void Start()
    {
        updatePosition = null;
    }
    public void OnMouseDown()
    {
        updatePosition = SetPosition;
        btnUse.SetActive(true);
    }
    private void Update()
    {
        if(updatePosition != null)
            updatePosition.Invoke();
    }

    private void SetPosition()
    {
        gameObject.transform.position = holdPoint.position;
    }
}
