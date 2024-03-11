using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private int lives;

    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SetupInputListeners();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveDirection = 
            GameManager.
            Instance.
            inputManager.
            MoveDirection;
        float fixedMoveDirection = moveDirection * 
                                   velocity * 
                                   Time.deltaTime;
        transform.Translate(fixedMoveDirection, 0, 0);
    }
    
    private void HandleAttack()
    {
        print("Estou atacando");
    }

    private void HandleJump()
    {
        print("Estou pulando");
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
