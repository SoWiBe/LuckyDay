using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficLight : MonoBehaviour
{
    [SerializeField] private GameObject firstColor, secondColor;
    private Image m_spriterOne, m_spriterTwo;
    [SerializeField] private Color lightGreen, mainGreen, lightRed, mainRed;

    private Action changeColor;

    private void Start()
    {
        m_spriterOne = firstColor.GetComponent<Image>();
        m_spriterTwo = secondColor.GetComponent<Image>();


        //m_spriterOne.color = new Color(102, 0, 0, 255);
        //m_spriterTwo.color = new Color(51, 152, 0, 255);
        //changeColor = RedStart;
        //changeColor.Invoke();
    }

    private void GreenStart()
    {
        m_spriterOne.color = mainGreen;
        m_spriterTwo.color = lightRed;
        StartCoroutine(DoRed());
    }

    private void RedStart()
    {
        m_spriterOne.color = lightGreen;
        m_spriterTwo.color = mainRed;
        StartCoroutine(DoGreen());
    }

    IEnumerator DoGreen()
    {
        yield return new WaitForSeconds(10f);

        changeColor = GreenStart;
        changeColor.Invoke();
    }

    IEnumerator DoRed()
    {
        yield return new WaitForSeconds(5f);

        changeColor = RedStart;
        changeColor.Invoke();
    }


}
