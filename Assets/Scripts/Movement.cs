using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 200f;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _isGround = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float direction = Input.GetAxis("Horizontal");

        _rigidbody2D.velocity = new Vector2(direction * _speed, _rigidbody2D.velocity.y);
        _animator.SetFloat("Speed", Mathf.Abs(direction));
        _spriteRenderer.flipX = direction < 0 ? true : false;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
            _rigidbody2D.AddForce(Vector2.up *  _jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground _))
        {
            _isGround = true;
            _animator.SetBool("isJumping", _isGround);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground _))
        {
            _isGround = false;
            _animator.SetBool("isJumping", _isGround);
        }
    }
}
