using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float _moveSpeed = 5f;




    private Vector2 _movement;

    private Rigidbody2D _rb;
    private Animator _animator;

    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);
        _rb.velocity = _movement * _moveSpeed;

        _animator.SetFloat(_horizontal, _movement.x);
        _animator.SetFloat(_vertical, _movement.y);



        if(_movement != Vector2.zero)
        {
            _animator.SetFloat(_lastHorizontal, _movement.x);
            _animator.SetFloat(_lastVertical, _movement.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            DeathSequence();
        }
    }

    public GameObject Player;

    private void DeathSequence()
    {
        enabled = false;
        GetComponent<BombController>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;

        SpriteRenderer spriteRenderer = Player.GetComponent<SpriteRenderer>();
        CircleCollider2D circleCollider2D = Player.GetComponent<CircleCollider2D>();
        spriteRenderer.enabled = false;
        circleCollider2D.enabled = false;
    }



}
