using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeMovement : MonoBehaviour
{
    float moveSpeed = 1f;
    Rigidbody2D enemyRigidBody;
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        enemyRigidBody.velocity = new Vector2(moveSpeed, 0f);
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        FlipSprite();
    }

    void FlipSprite()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidBody.velocity.x)), 1f);
    }
}
