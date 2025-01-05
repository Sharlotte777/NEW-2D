using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action AmountChanged;

    public float RealHealth { get; private set; } = 100f;
    public float MaxHealth { get; private set; } = 100f;
    public bool IsAlive { get; private set; } = true;
    public bool HaveMaxHealth { get; private set; } = true;

    public void TakeDamage(int damage)
    {
        if (RealHealth < damage)
        {
            RealHealth = 0;
        }
        else
        {
            RealHealth -= damage;
        }

        if (RealHealth <= 0)
        {
            gameObject.SetActive(false);
            IsAlive = false;
        }

        HaveMaxHealth = RealHealth >= MaxHealth;
        AmountChanged?.Invoke();
    }

    public bool HaveRecovered(int recoveryAmount)
    {
        if (HaveMaxHealth == false)
        {
            Recover(recoveryAmount);

            return true;
        }

        return false;
    }

    public void Recover(int recoveryAmount)
    {
        if (RealHealth + recoveryAmount > MaxHealth)
        {
            RealHealth = MaxHealth;
        }
        else
        {
            RealHealth += recoveryAmount;
        }

        HaveMaxHealth = RealHealth >= MaxHealth;
        AmountChanged?.Invoke();
    }
}
