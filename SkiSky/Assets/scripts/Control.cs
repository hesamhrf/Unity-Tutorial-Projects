using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour { 

    [SerializeField] float torqueAmount = 3f;
    bool canControl = true;

    Rigidbody2D rigidBody;

    public void DisableControl()
    {
        canControl = false;
    }
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        InputControl();

    }

    private void InputControl()
    {
        if (canControl)
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rigidBody.AddTorque(torqueAmount);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rigidBody.AddTorque(-torqueAmount);
            }
        }
    }
}
