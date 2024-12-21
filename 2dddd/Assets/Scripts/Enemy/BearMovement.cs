using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BearSearcher))]
public class BearMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private BearSearcher _enemySearch;

    private void Awake()
    {
        _enemySearch = GetComponent<BearSearcher>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _enemySearch.GetTargetToFollow().position, _speed * Time.deltaTime);
    }
}
