using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float jumpForce = 300;
    [SerializeField] private int lives;

    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;

    private float moveDirection;
    private bool canJump = false;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetupInputListeners();
    }

    private void Update()
    {
        Move();
        FlipSpriteAccordingToMoveDirection();
    }

    private void Move()
    {
        moveDirection =
            GameManager.Instance.inputManager.MoveDirection;
        float fixedMoveDirection = moveDirection *
                                   velocity *
                                   Time.deltaTime;
        transform.Translate(fixedMoveDirection, 0, 0);
    }

    private void FlipSpriteAccordingToMoveDirection()
    {
        if (moveDirection > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveDirection < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void HandleAttack()
    {
        print("Estou atacando");
    }

    private void HandleJump()
    {
        if (canJump)
        {
            rigidbody.AddForce(Vector2.up * jumpForce);
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Floor"))
        {
            canJump = true;
        }
    }

    public bool GetCanJump()
    {
        return canJump;
    }

    private void SetupInputListeners()
    {
        GameManager.Instance.inputManager.OnJump += HandleJump;
        GameManager.Instance.inputManager.OnAttack += HandleAttack;
    }

    private void OnDestroy()
    {
        GameManager.Instance.inputManager.OnJump -= HandleJump;
        GameManager.Instance.inputManager.OnAttack -= HandleAttack;
    }
}