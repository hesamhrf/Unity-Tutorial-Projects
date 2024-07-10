using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class endscreen : MonoBehaviour
{
    [SerializeField]Score score;
    [SerializeField]TextMeshProUGUI scoreText;
    void Start()
    {
        score = FindObjectOfType<Score>();
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
    }


    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Your score {score.GetScore()}%";
    }
}
