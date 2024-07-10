using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(2);
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCount >= index)
        {
            FindObjectOfType<prsist>().Restart();
            SceneManager.LoadScene(index);

        }
    }
}
