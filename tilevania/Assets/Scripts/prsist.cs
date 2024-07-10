using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prsist : MonoBehaviour
{
    private void Awake()
    {
        if (FindObjectsOfType<prsist>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Restart(){
        Destroy(gameObject);
    }
}
