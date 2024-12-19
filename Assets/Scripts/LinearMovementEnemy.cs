using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovementEnemy : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 2f;                      
    public Vector2 initialDirection = Vector2.right; 
    private Vector2 movementDirection;

    [Header("Collision Settings")]
    public LayerMask collisionLayerMask;

    private Rigidbody2D rb2d;
    private BoxCollider2D enemyCollider;
    private bool isMoving = true;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<BoxCollider2D>();

        movementDirection = initialDirection.normalized;
    }

    private void Update()
    {
        if (isMoving)
        {
            rb2d.velocity = movementDirection * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            Vector2 collisionNormal = collision.contacts[0].normal;
            if (Mathf.Abs(collisionNormal.x) > Mathf.Abs(collisionNormal.y))
            {
                movementDirection.x = -movementDirection.x;
            }
            else if (Mathf.Abs(collisionNormal.y) > Mathf.Abs(collisionNormal.x))
            {
                movementDirection.y = -movementDirection.y;
            }
        }
    }

    public void StopMovement()
    {
        isMoving = false;
        rb2d.velocity = Vector2.zero;
    }

    public void ResumeMovement()
    {
        isMoving = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            Destroy(gameObject);
        }
    }
}
