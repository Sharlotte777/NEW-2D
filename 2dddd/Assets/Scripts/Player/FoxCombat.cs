using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class FoxCombat : MonoBehaviour
{
    [SerializeField] private int _damage;

    private float _rechargeTime = 1f;
    private float _timeBetweenAttack;
    private InputReader _reader;

    private void Awake()
    {
        _reader = GetComponent<InputReader>();
    }

    public void Hit(BearHealth enemy)
    {
        if (_reader.CanAttack)
        {
            if (_timeBetweenAttack <= 0)
            {
                enemy.TakeDamage(_damage);
                _timeBetweenAttack = _rechargeTime;
            }
            else
            {
                _timeBetweenAttack -= Time.deltaTime;
            }
        }
    }
}
