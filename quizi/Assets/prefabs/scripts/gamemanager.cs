using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    endscreen end;
    Quiz quiz;
    void Start()
    {
        end = FindObjectOfType<endscreen>();
        quiz = FindObjectOfType<Quiz>();

        quiz.gameObject.SetActive(true);
        end.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (quiz.IsComplete())
        {
            quiz.gameObject.SetActive(false);
            end.gameObject.SetActive(true);
        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
