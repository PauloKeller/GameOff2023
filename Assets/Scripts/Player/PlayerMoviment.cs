using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    Rigidbody2D playerRigidbody2D;
    CapsuleCollider2D playerCapsuleCollider2D;
    Vector2 moveInput;
    bool isAlive = true;

    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (!isAlive) { return; }

        Run();
        Die();
    }

    void OnJump(InputValue value) 
    {
        HandleJump(value);
    }

    void HandleJump(InputValue value) 
    {
        if (!playerCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;

        if (value.isPressed) 
        {
            playerRigidbody2D.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void OnMove(InputValue value) 
    {
        moveInput = value.Get<Vector2>();
    }

    void Run() 
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, playerRigidbody2D.velocity.y);
        playerRigidbody2D.velocity = playerVelocity;
    }
    void Die() 
    {
        if (playerCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemies"))) 
        {
            isAlive = false;
        }
    }
}
