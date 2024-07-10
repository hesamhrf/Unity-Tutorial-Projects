using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    const float timeToCompleteQuestion = 30f;
    const float timeToShowCorrectAns = 5f;
    public bool isAnsweringQuestion = false;
    float timerValue;
    public bool loadNextQuestion;
    public float fillFraction;
    public bool isTimeFinish = false;

    void Update()
    {
        UpdateTimer();
    }

    float CalculateFullTime()
    {
        if (!isAnsweringQuestion)
        {
            return timeToCompleteQuestion;
        }
        else
        {
            return timeToShowCorrectAns;
        }
    }
    private void Start()
    {
        timerValue = CalculateFullTime();
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
       if(timerValue > 0)
        {
            fillFraction = timerValue / CalculateFullTime();
        }
        else
        {
            if (isAnsweringQuestion)
            {
                loadNextQuestion = true;
                isAnsweringQuestion = false;
            }
            else
            {
                isAnsweringQuestion = true;
            }
            timerValue = CalculateFullTime();
        }
    }
    public void CancelTimer()
    {
        timerValue = 0;
        isAnsweringQuestion = false;
    }
}
