using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FoxSearcher))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(InputReader))]
public class FoxMovement : MonoBehaviour
{
    private const string NameOfAxis = "Horizontal";
    private const string NameOfValue = "speed";

    [SerializeField] private float _speedOfMovement;
    [SerializeField] private float _jumpForce = 500;

    private bool _isJump = false;
    private float movement = 0f;
    private FoxSearcher _search;
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private bool _turnedToTheRight = true;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _search = GetComponent<FoxSearcher>();
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        movement = _inputReader.ReturnAxis(NameOfAxis);
        _animator.SetFloat(NameOfValue, Mathf.Abs(movement));

        if (_turnedToTheRight == false && movement > 0)
        {
            Flip();
        }
        else if (_turnedToTheRight && movement < 0)
        {
            Flip();
        }

        if (_inputReader.CanJump && _groundDetector.IsGrounded())
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
