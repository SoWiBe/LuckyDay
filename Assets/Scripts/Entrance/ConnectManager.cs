using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectManager : MonoBehaviour
{
    [SerializeField] private GameConnectLine[] connectionLines;
    [SerializeField] private GameObject[] roomLights;
    [SerializeField] private GameObject[] kitchenLights;
    [SerializeField] private GameObject[] entranceLights;
    public bool isGame { get; set; }
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
            TurnOnLight(roomLights);
        }
        
    }
    private void CheckStepTwo()
    {
        if (connectionLines[1].isConnected)
        {
            isStepTwo = false;
            TurnOnLight(kitchenLights);
        }
    }
    private void CheckStepThree()
    {
        if (connectionLines[2].isConnected)
        {
            isStepThree = false;
            TurnOnLight(entranceLights);
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

    private void TurnOnLight(GameObject[] lights)
    {
        foreach (var item in lights)
        {
            item.SetActive(true);
        }
    }

}
