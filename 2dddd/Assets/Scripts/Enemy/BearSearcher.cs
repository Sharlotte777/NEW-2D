using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BearAttack))]
[RequireComponent(typeof(BearHealth))]
public class BearSearcher : MonoBehaviour
{
    [SerializeField] private Transform[] _moveSpots;

    private int _currentPoint = 0;
    private int _indexOfLeftPoint = 0;
    private int _indexOfRightPoint = 1;
    private bool _turnedToTheRight = true;
    private float _radiusToFollow = 3f;
    private BearAttack _enemyAttack;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _enemyAttack = GetComponent<BearAttack>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    public Transform GetTargetToFollow()
    {
        Transform objectToFollow = _moveSpots[_currentPoint];
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, _radiusToFollow);

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

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].gameObject.TryGetComponent(out FoxHealth player))
            {
                objectToFollow = player.transform;

                _enemyAttack.Hit(player);
            }
        }

        return objectToFollow;
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
