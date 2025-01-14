using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action AmountChanged;

    public float CurrentValue { get; private set; } = 100f;
    public float MaxValue { get; private set; } = 100f;
    public bool IsAlive { get; private set; } = true;
    public bool HaveMaxValue { get; private set; } = true;

    public void TakeDamage(int damage)
    {
        if (CurrentValue < damage)
        {
            CurrentValue = 0;
        }
        else
        {
            CurrentValue -= damage;
        }

        if (CurrentValue <= 0)
        {
            gameObject.SetActive(false);
            IsAlive = false;
        }

        HaveMaxValue = CurrentValue >= MaxValue;
        AmountChanged?.Invoke();
    }

    public bool HaveRecovered(int recoveryAmount)
    {
        if (HaveMaxValue == false)
        {
            Recover(recoveryAmount);

            return true;
        }

        return false;
    }

    public void Recover(int recoveryAmount)
    {
        if (CurrentValue + recoveryAmount > MaxValue)
        {
            CurrentValue = MaxValue;
        }
        else
        {
            CurrentValue += recoveryAmount;
        }

        HaveMaxValue = CurrentValue >= MaxValue;
        AmountChanged?.Invoke();
    }
}
