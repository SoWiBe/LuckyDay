using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectManager : MonoBehaviour
{
    [SerializeField] private GameConnectLine[] connectionLines;
    private bool isGame { get; set; }
    private bool isStepOne { get; set; }
    private bool isStepTwo { get; set; }
    private bool isStepThree { get; set; }
    private bool isStepFour { get; set; }

    private void Start()
    {
        isGame = true;
        isStepOne = true;
        isStepTwo = true;
        isStepThree = true;
        isStepFour = true;
    }
    private void Update()
    {
        if (isGame)
        {
            if (isStepOne)
                CheckStepOne();
            if (isStepTwo)
                CheckStepTwo();
            if (isStepThree)
                CheckStepThree();
            if (isStepFour)
                CheckStepFour();
        } 
    }

    private void CheckStepOne()
    {
        if (connectionLines[0].isConnected)
        {
            isStepOne = false;
        }
        
    }
    private void CheckStepTwo()
    {
        if (connectionLines[1].isConnected)
        {
            isStepTwo = false;
        }
        
    }
    private void CheckStepThree()
    {
        if (connectionLines[2].isConnected)
        {
            isStepThree = false;
        }
    }

    private void CheckStepFour()
    {
        if (connectionLines[3].isConnected)
        {
            isStepFour = false;
            isGame = false;
        }
    }

}
