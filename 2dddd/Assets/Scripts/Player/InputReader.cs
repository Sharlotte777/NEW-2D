using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action AbilityOfAttackChanged;
    public event Action AbilityOfDrainChanged;

    private int _attackKey = 0;
    private KeyCode _jumpKey = KeyCode.Space;
    private KeyCode _vampirismKey = KeyCode.E;

    public bool CanJump { get; private set; }

    public void Update()
    {
        if (Input.GetMouseButton(_attackKey))
        {
            AbilityOfAttackChanged?.Invoke();
        }
        else if (Input.GetKeyDown(_jumpKey))
        {
            CanJump = true;
        }
        else if (Input.GetKeyDown(_vampirismKey))
        {
            AbilityOfDrainChanged?.Invoke();
        }
        else
        {
            CanJump = false;
        }
    }

    public float ReturnAxis(string axis)
    {
        return Input.GetAxis(axis);
    }
}
