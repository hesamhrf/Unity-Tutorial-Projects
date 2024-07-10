using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class finish : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    private void Start()
    {
         explosion = GameObject.Find("finishex").GetComponent<ParticleSystem>();
    }

    private void Reload()
    {
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            explosion.Play();
            Invoke("Reload",3f);
        }
    }
}
