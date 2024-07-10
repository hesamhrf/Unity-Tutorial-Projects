using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    const char HORIZONTAL = 'H';
    const char VERTICAL = 'V';

    bool isPlayerAlive = true;
    Rigidbody2D playerRigidBody;
    Animator playerAnimator;

    CapsuleCollider2D playerBodyCollider;

    BoxCollider2D playerFeetCollider;
    Vector2 moveInput;

    float startGravityScale;

    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float playerJumpSpeed = 13f;

    [SerializeField] float playerClimbSpeed = 6f;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerBodyCollider = GetComponent<CapsuleCollider2D>();
        playerFeetCollider = GetComponent<BoxCollider2D>();
        startGravityScale = playerRigidBody.gravityScale;
    }

    void Update()
    {
        if (isPlayerAlive)
        {
            Die();
            Run();
            Climb();
        }
    }

    void OnMove(InputValue value)
    {
        if (isPlayerAlive)
        {
            moveInput = value.Get<Vector2>();
        }
    }

    void OnJump(InputValue value)
    {
        if (isPlayerAlive)
        {
            if (playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                if (value.isPressed)
                {
                    playerRigidBody.velocity += new Vector2(0f, playerJumpSpeed);
                }
            }
        }
    }

    bool IsPlayerMoveing(char direction)
    {
        float velocity = 0f;
        if (direction == HORIZONTAL)
        {
            velocity = playerRigidBody.velocity.x;
        }
        else if (direction == VERTICAL)
        {
            velocity = playerRigidBody.velocity.y;
        }
        return Mathf.Abs(velocity) > Mathf.Epsilon;
    }

    void Run()
    {
        playerRigidBody.velocity = new Vector2((moveInput.x * playerSpeed), playerRigidBody.velocity.y);
        if (IsPlayerMoveing(HORIZONTAL))
        {
            FlipSprite();
            playerAnimator.SetBool("isRuning", true);
        }
        else
        {
            playerAnimator.SetBool("isRuning", false);
        }
    }

    void Climb()
    {
        if (playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climb")))
        {
            playerRigidBody.gravityScale = 0f;
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, (moveInput.y * playerClimbSpeed));
            playerAnimator.SetBool("isClimbing", IsPlayerMoveing(VERTICAL));
        }
        else
        {
            playerRigidBody.gravityScale = startGravityScale;
            playerAnimator.SetBool("isClimbing", false);
        }
    }
    void FlipSprite()
    {
        transform.localScale = new Vector2(Mathf.Sign(playerRigidBody.velocity.x), 1f);
    }

    void Die()
    {
        if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("enemy")) || playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Spikes")))
        {
            isPlayerAlive = false;
            playerAnimator.SetTrigger("dying");
            playerRigidBody.velocity = new Vector2(0, 20);
            FindObjectOfType<ScenesManage>().TakeLive();
        }
    }
}
