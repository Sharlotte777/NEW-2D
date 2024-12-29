using System;
using UnityEngine;
using UnityEngine.Events;

public class FoxHealth : MonoBehaviour
{
    public event Action AmountChanged;

    public float Health { get; private set; } = 100f;
    public float MaxHealth { get; private set; } = 100f;
    public bool IsAlive { get; private set; } = true;

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            gameObject.SetActive(false);
            IsAlive = false;
        }

        AmountChanged?.Invoke();
    }

    public bool HaveRecovered(int recoveryAmount)
    {
        if (!HaveMaxHealth())
        {
            Recover(recoveryAmount);

            return true;
        }

        return false;
    }

    public void Recover(int recoveryAmount)
    {
        if (Health + recoveryAmount > MaxHealth)
        {
            Health = MaxHealth;
        }
        else
        {
            Health += recoveryAmount;
        }

        AmountChanged?.Invoke();
    }

    private bool HaveMaxHealth()
    {
        return Health >= MaxHealth;
    }
}
