using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerSearcher))]
public class BearMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerSearcher _enemySearch;

    private void Awake()
    {
        _enemySearch = GetComponent<PlayerSearcher>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _enemySearch.GetTargetToFollow(), _speed * Time.deltaTime);
    }
}
