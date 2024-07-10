using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;
    [SerializeField] TextMeshProUGUI textMashQuestion;
    [SerializeField]GameObject[] awnsers;
    [SerializeField] Sprite defulltSprite;
    [SerializeField] Sprite selectSprite;
    [SerializeField] Sprite correctSprite;
    [SerializeField] Image timerImage;
    Timer timer;
    bool isClick = false;
    Score score;
    [SerializeField] Slider slider;
    

    QuestionSO FindRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        QuestionSO question = questions[index];
        questions.RemoveAt(index);
        return question; 
    }

    public bool IsComplete()
    {
        if(slider.value == slider.maxValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void GetNewQuestion()
    {
        if(questions.Count > 0)
        {
            isClick = false;
            SetButtonState(true);
            ResetSprites();
            currentQuestion = FindRandomQuestion();
            SetValues();
            slider.value++;
            score.AddNumberOfQuestion();
            setPage();
        }
       
    }

    void SetButtonState(bool state)
    {
        for(int i =0; i < awnsers.Length; i++)
        {
            awnsers[i].GetComponent<Button>().interactable = state;
        }
    }
    void SetValues()
    {
        textMashQuestion = GameObject.Find("question").GetComponentInChildren<TextMeshProUGUI>();
        awnsers = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            awnsers[i] = GameObject.Find($"AnswerButton({i})");
        }
    }
    void setPage()
    {
        textMashQuestion.text = currentQuestion.Question;
        for(int i=0; i < 4; i++){
            awnsers[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.getAwnser(i);
        }
    }
    void Start()
    {
        slider.value = 0;
        slider.maxValue = questions.Count;
        timer = FindObjectOfType<Timer>();
        score = FindObjectOfType<Score>();
        GetNewQuestion();
    }

    void ResetSprites()
    {
        for(int i=0; i < awnsers.Length; i++)
        {
            awnsers[i].GetComponent<Image>().sprite = defulltSprite;
        }
    }
   public void OnAwnserSelected(int index)
    {
        awnsers[index].GetComponent<Image>().sprite =selectSprite;
        if (index == currentQuestion.CorrectAwnserIndex)
        {
            textMashQuestion.text = "Correct :)";
            score.AddCorrectAns();
        }
        else
        {
            textMashQuestion.text = "Wrong :(";
        }
        awnsers[currentQuestion.CorrectAwnserIndex].GetComponent<Image>().sprite = correctSprite;
        timer.CancelTimer();
        SetButtonState(false);
        isClick = true;
    }


    
    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            timer.loadNextQuestion = false;
            GetNewQuestion();

        }
        else if (timer.isAnsweringQuestion && !isClick)
        {
            awnsers[currentQuestion.CorrectAwnserIndex].GetComponent<Image>().sprite = correctSprite;
            textMashQuestion.text = "Your Time Over!";
            
        }
    }
}
