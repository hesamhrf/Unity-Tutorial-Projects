using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class groundHit : MonoBehaviour
{
    void Reload()
    {
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {

            FindObjectOfType<Control>().DisableControl();
            Invoke("Reload", 3f);
        }
    }
}
