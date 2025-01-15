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
    private bool _isAttacking = false;

    private void Awake()
    {
        _reader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _reader.AbilityOfAttackChanged += ChangeAbilityOfAttack;
    }

    private void OnDisable()
    {
        _reader.AbilityOfAttackChanged -= ChangeAbilityOfAttack;
    }

    public void Hit(BearHealth enemy)
    {
        if (_isAttacking)
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

    private void ChangeAbilityOfAttack()
    {
        _isAttacking = !_isAttacking;
    }
}
