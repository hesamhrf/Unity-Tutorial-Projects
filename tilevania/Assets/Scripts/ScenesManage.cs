using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ScenesManage : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI CoinUI;
    [SerializeField] TextMeshProUGUI LiveUI;

    [SerializeField] int numOfCoins = 0;

    [SerializeField] int numOfLives = 3;
    private void Awake()
    {
        if (FindObjectsOfType<ScenesManage>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        CoinUI.text = numOfCoins.ToString();
        LiveUI.text = numOfLives.ToString();
    }

    public void AddCoin(int value)
    {
        numOfCoins += value;
        CoinUI.text = numOfCoins.ToString();
    }

    public void TakeLive()
    {
        if (numOfLives > 0)
        {
            numOfLives--;
            LiveUI.text = numOfLives.ToString();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            RestartGame();
        }
    }


    public void RestartGame()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
        FindObjectOfType<prsist>().Restart();
    }
}
