using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameExample : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] examples;
    [SerializeField] private Text[] txtAnswers;
    [SerializeField] private Text[] numbersOfAnswers;
    [SerializeField] private Image[] imagesForAnswers;
    [SerializeField] private Sprite correctSprite, incorrectSprite;
    [SerializeField] private Table table;
    [SerializeField] private DialogueTrigger dialogue;
    [SerializeField] private GameObject timer;
    [SerializeField] private TextMeshProUGUI textTimer;
    private List<int> numbersOne;
    private List<int> answers;

    public int CurrentPosition { get; set; }

    private void Start()
    {
        numbersOne = new List<int>();
        answers = new List<int>();

        CurrentPosition = 0;

        SetValues();
        SetButtonsValue(UnityEngine.Random.Range(0, 3), answers[CurrentPosition]);
    }

    private void SetValues()
    {
        for (int i = 0; i < 8; i++)
        {
            numbersOne.Add(UnityEngine.Random.Range(1, 10));
        }
        GenerateExample(examples[0], numbersOne[0], numbersOne[1], "+");
        GenerateExample(examples[1], numbersOne[2], numbersOne[3], "*");
        GenerateExample(examples[2], numbersOne[4], numbersOne[5], "+");
        GenerateExample(examples[3], numbersOne[6], numbersOne[7], "*");
    }

    private void GenerateExample(TextMeshProUGUI example, int firstNumber, int secondNumber, string operation)
    {
        example.text += firstNumber + $" {operation} " + secondNumber + " = ";
        switch (operation)
        {
            case "+":
                answers.Add(firstNumber + secondNumber);
                break;
            case "*":
                answers.Add(firstNumber * secondNumber);
                break;
            default:
                break;
        }
    }
    private void SetButtonsValue(int position, int answer)
    {
        ClearAnswers();
        for (int i = 0; i < 4; i++)
        {
            if (i == position)
                txtAnswers[i].text += answer;
            else
                txtAnswers[i].text += UnityEngine.Random.Range(1, 100);
        }
    }


    public void NextAnswer(Text choosedAnswer)
    {
        CheckAnswer(answers[CurrentPosition], Convert.ToInt32(choosedAnswer.text));
        
    }

    private void CheckAnswer(int correctAnswer, int checkAnswer)
    {
        imagesForAnswers[CurrentPosition].sprite = incorrectSprite;
        if(correctAnswer == checkAnswer)
        {
            Debug.Log("Все верно!");
            imagesForAnswers[CurrentPosition].sprite = correctSprite;
            numbersOfAnswers[CurrentPosition].text = correctAnswer.ToString();
            CurrentPosition++;
        }
        if (CurrentPosition < 4)
            SetButtonsValue(UnityEngine.Random.Range(0, 3), answers[CurrentPosition]);
        else
            SetGameFinal();
    }

    private void ClearAnswers()
    {
        for (int i = 0; i < 4; i++)
        {
            txtAnswers[i].text = "";
        }
    }

    private void SetGameFinal()
    {
        table.CloseTetrad();
        dialogue.StartDialog();
        timer.SetActive(false);
        textTimer.text = "";
    }
}
