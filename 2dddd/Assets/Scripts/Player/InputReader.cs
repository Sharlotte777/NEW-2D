using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public bool CanJump { get; private set; }
    public bool CanAttack { get; private set; }

    private int _attackKey = 0;
    private KeyCode _jumpKey = KeyCode.Space;

    public void Update()
    {
        if (Input.GetMouseButton(_attackKey))
        {
            CanAttack = true;
        }
        else if (Input.GetKeyDown(_jumpKey))
        {
            CanJump = true;
        }
        else
        {
            CanJump = false;
            CanAttack = false;
        }
    }

    public float ReturnAxis(string axis)
    {
        return Input.GetAxis(axis);
    }
}
