using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Vector2 rawInput = new Vector2(0, 0);

    Vector2 minBound;
    Vector2 maxBound;

    Dictionary<string, float> padings = new Dictionary<string, float>{
        {"Left" , 0.5f},
        {"Right" , 0.5f},
        {"Top" , 3f},
        {"Bottom" , 2f}
    };

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    void Update()
    {
        Move();
    }

    void Start()
    {
        InitBounds();
    }

    private void Move()
    {
        Vector3 delta = (rawInput * speed * Time.deltaTime);
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(delta.x + transform.position.x, minBound.x + padings["Left"], maxBound.x - padings["Right"]);
        newPos.y = Mathf.Clamp(delta.y + transform.position.y, minBound.y + padings["Bottom"], maxBound.y - padings["Top"]);
        transform.position = newPos;
    }
}
