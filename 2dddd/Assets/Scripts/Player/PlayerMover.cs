using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerSearch))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(InputReader))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedOfMovement;
    [SerializeField] private float _jumpForce = 500;

    private const string _nameOfAxis = "Horizontal";
    private const string _nameOfValue = "speed";

    private bool _isGrounded = false;
    private bool _isJump = false;
    private float movement = 0f;
    private PlayerSearch _search;
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private InputReader _inputReader;
    private bool _turnedToTheRight = true;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _search = GetComponent<PlayerSearch>();
        _inputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        movement = Input.GetAxis(_nameOfAxis);
        _animator.SetFloat(_nameOfValue, Mathf.Abs(movement));

        if (_turnedToTheRight == false && movement > 0)
        {
            Flip();
        }
        else if (_turnedToTheRight == true && movement < 0)
        {
            Flip();
        }

        if (_inputReader.CheckForJumpKeyPress() && _isGrounded)
        {
            _isJump = true;
        }

        _search.StartDetection();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(movement * _speedOfMovement, _rigidBody.velocity.y);

        if (_isJump)
        {
            _rigidBody.AddForce(new Vector2(_rigidBody.velocity.x, _jumpForce));
            _isJump = false;
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Ground _))
        {
            _isGrounded = true;
        }
    }

    private void Flip()
    {
        int rotationDegrees = 180;
        _turnedToTheRight = !_turnedToTheRight;
        Vector2 rotate = transform.eulerAngles;
        rotate.y += rotationDegrees;
        transform.rotation = Quaternion.Euler(rotate);
    }
}
