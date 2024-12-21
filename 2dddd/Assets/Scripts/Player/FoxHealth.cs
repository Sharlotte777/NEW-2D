using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxHealth : MonoBehaviour
{
    private int _health = 100;
    private int _maxHealth = 100;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public bool HaveRecovered(int recoveryAmount)
    {
        if (_health < _maxHealth)
        {
            if (_health + recoveryAmount > _maxHealth)
            {
                _health = _maxHealth;
            }
            else
            {
                _health += recoveryAmount;
            }

            return true;
        }

        return false;
    }
}
