using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Constants
{
    public const float DEFAULT_ROTATION_SPEED = 200;
    public const int DEFAULT_MOVE_SPEED = 10;
}

public class Car : MonoBehaviour
{
    [SerializeField]private float rotationSpeed;
    [SerializeField]private float moveSpeed;
    public Car()
    {
        rotationSpeed = Constants.DEFAULT_ROTATION_SPEED;
        moveSpeed = Constants.DEFAULT_MOVE_SPEED;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(moveSpeed != Constants.DEFAULT_MOVE_SPEED)
        {
            moveSpeed = Constants.DEFAULT_MOVE_SPEED;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boost" && moveSpeed == Constants.DEFAULT_MOVE_SPEED)
        {
            moveSpeed += 5;
        }
    }

    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float rotationAmount = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
        if(moveAmount != 0)
        {
            transform.Rotate(0, 0, -rotationAmount);
        }
       
    }
}
