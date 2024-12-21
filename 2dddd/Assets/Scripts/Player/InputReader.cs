using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private int _attackKey = 0;
    private KeyCode _jumpKey = KeyCode.Space;

    public bool CanAttack()
    {
        return (Input.GetMouseButton(_attackKey));
    }

    public bool CanJump()
    {
        return (Input.GetKeyDown(_jumpKey));
    }

    public float ReturnAxis(string axis)
    {
        return Input.GetAxis(axis);
    }
}
