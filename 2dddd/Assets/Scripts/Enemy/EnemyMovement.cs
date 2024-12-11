using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(EnemySearcher))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private EnemySearcher _enemySearch;

    private void Awake()
    {
        _enemySearch = GetComponent<EnemySearcher>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _enemySearch.GetTargetToFollow().position, _speed * Time.deltaTime);
    }
}
