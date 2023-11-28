using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 20f;

    Rigidbody2D playerRigidbody2D;
    CapsuleCollider2D playerBodyCollider2D;
    BoxCollider2D playerFeetCollider;
    Player player;
    Vector2 moveInput;
    Animator playerAnimator;

    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerBodyCollider2D = GetComponent<CapsuleCollider2D>();
        playerFeetCollider = GetComponent<BoxCollider2D>();
        player = GetComponent<Player>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!player.IsAlive) { return; }

        Run();
        FlipSprite();
    }

    void OnJump(InputValue value)
    {
        HandleJump(value);
    }

    void HandleJump(InputValue value)
    {
        if (!playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;

        if (value.isPressed)
        {
            playerRigidbody2D.velocity += new Vector2(0f, jumpForce);
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

        bool playerHasHorizontalSpeed = Mathf.Abs(playerRigidbody2D.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("IsRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(playerRigidbody2D.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRigidbody2D.velocity.x), 1f);
        }
    }
}
