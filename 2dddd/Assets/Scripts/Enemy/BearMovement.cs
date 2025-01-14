using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerSearcher))]
public class BearMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerSearcher _enemySearch;
    private int _indexOfLeftPoint = 0;
    private int _indexOfRightPoint = 1;
    private bool _turnedToTheRight = true;

    private void Awake()
    {
        _enemySearch = GetComponent<PlayerSearcher>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _enemySearch.GetTargetToFollow(), _speed * Time.deltaTime);
    }

    public void CheckForFlip(int point)
    {
        if ((point == _indexOfLeftPoint) & (_turnedToTheRight == false))
        {
            _turnedToTheRight = true;
            Flip();
        }
        else if ((point == _indexOfRightPoint) & (_turnedToTheRight))
        {
            _turnedToTheRight = false;
            Flip();
        }
    }

    private void Flip()
    {
        int rotationDegree = 180;
        transform.Rotate(0, rotationDegree, 0) ;
    }
}