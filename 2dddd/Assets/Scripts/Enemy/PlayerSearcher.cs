using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BearAttack))]
[RequireComponent(typeof(BearHealth))]
public class PlayerSearcher : MonoBehaviour
{
    [SerializeField] private Transform[] _moveSpots;
    [SerializeField] private float _timeToRepeat = 0.01f;

    private int _currentPoint = 0;
    private int _indexOfLeftPoint = 0;
    private int _indexOfRightPoint = 1;
    private bool _turnedToTheRight = true;
    private float _radiusToFollow = 3f;
    private BearAttack _enemyAttack;
    private SpriteRenderer _sprite;
    private bool _isWorking = true;
    private WaitForSeconds _wait;
    private Collider2D[] _objects;

    private void Awake()
    {
        _enemyAttack = GetComponent<BearAttack>();
        _sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(SearchObjects());
    }

    public Vector2 GetTargetToFollow()
    {
        Transform objectToFollow = _moveSpots[_currentPoint];

        if (transform.position == objectToFollow.position)
        {
            if ((_currentPoint == _indexOfLeftPoint) & (_turnedToTheRight == false))
            {
                Flip();
            }
            else if ((_currentPoint == _indexOfRightPoint) & (_turnedToTheRight))
            {
                Flip();
            }

            _currentPoint = ++_currentPoint % _moveSpots.Length;
        }

        for (int i = 0; i < _objects.Length; i++)
        {
            if (_objects[i].gameObject.TryGetComponent(out FoxHealth player))
            {
                objectToFollow = player.transform;

                _enemyAttack.Hit(player);
            }
        }

        return objectToFollow.position;
    }

    private IEnumerator SearchObjects()
    {
        _wait = new WaitForSeconds(_timeToRepeat);

        while (_isWorking)
        {
            _objects = Physics2D.OverlapCircleAll(transform.position, _radiusToFollow);
            yield return _wait;
        }
    }

    private void Flip()
    {
        if (_turnedToTheRight)
        {
            _sprite.flipX = true;
            _turnedToTheRight = !_turnedToTheRight;
        }
        else
        {
            _sprite.flipX = false;
            _turnedToTheRight = !_turnedToTheRight;
        }
    }
}
