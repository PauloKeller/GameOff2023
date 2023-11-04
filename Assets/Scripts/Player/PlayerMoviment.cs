using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{
    Rigidbody2D playerRigidbody2D;
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 5f;

    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Run();
    }

    void OnMove(InputValue value) 
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void Run() 
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, playerRigidbody2D.velocity.y);
        playerRigidbody2D.velocity = playerVelocity;
    }
}
