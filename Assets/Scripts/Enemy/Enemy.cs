using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private float velocity = 5;
    [SerializeField] private int attackDamage;
    [SerializeField] private Transform pointLeft;
    [SerializeField] private Transform pointRight;

    private Rigidbody2D rigidbody;

    private Transform currentPointToMove;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        currentPointToMove = pointRight;
    }

    private void FixedUpdate()
    {
        if (currentPointToMove == pointRight)
        {
            rigidbody.velocity = Vector2.right * velocity;
        }
        else
        {
            rigidbody.velocity = Vector2.left * velocity;
        }

        
        if (Vector2.Distance(transform.position, pointRight.position) < 1f)
        {
            print("Changing to Left");
            currentPointToMove = pointLeft;
        }
        else if (Vector2.Distance(transform.position, pointLeft.position) < 1f)
        {
            print("Changing to right");
            currentPointToMove = pointRight;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pointLeft.position, 1);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pointRight.position, 1);
    }
}
