using UnityEngine;

[RequireComponent(typeof(TargetSearcer))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(FoxAnimator))]
public class FoxMovement : MonoBehaviour
{
    [SerializeField] private float _speedOfMovement;
    [SerializeField] private float _jumpForce = 500;

    private bool _isJump = false;
    private float movement = 0f;
    private TargetSearcer _search;
    private Rigidbody2D _rigidBody;
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private FoxAnimator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _turnedToTheRight = true;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _search = GetComponent<TargetSearcer>();
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<FoxAnimator>();
    }

    private void Update()
    {
        movement = _inputReader.ReturnAxis(_inputReader.NameOfAxis);
        _animator.StartRunningAnimation(movement);

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
        if (_turnedToTheRight)
        {
            _spriteRenderer.flipX = true;
            _turnedToTheRight = !_turnedToTheRight;
        }
        else
        {
            _spriteRenderer.flipX = false;
            _turnedToTheRight = !_turnedToTheRight;
        }
    }
}
