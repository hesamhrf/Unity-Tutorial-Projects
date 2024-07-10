using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] int correctAns;
    [SerializeField] int numberOfQuestion;
    [SerializeField]TextMeshProUGUI scoreText;


    public void AddCorrectAns()
    {
        correctAns++;
    }

    public void AddNumberOfQuestion()
    {
        numberOfQuestion++;
    }

     public int GetScore()
    {
        if(numberOfQuestion == 0)
        {
            return 0;
        }
        return Mathf.RoundToInt(correctAns / (float)numberOfQuestion * 100);
    }

    private void Start()
    {
        numberOfQuestion = 0;
        correctAns = 0;
        scoreText.text = $"Score 0%";
    }
    void Update()
    {
        scoreText.text = $"Score {GetScore()}%";
    }
}
