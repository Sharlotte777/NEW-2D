using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private int _attackKey = 0;
    private KeyCode _jumpKey = KeyCode.Space;

    public bool CheckForAttackKeyPress()
    {
        if (Input.GetMouseButton(_attackKey))
        {
            return true;
        }

        return false;
    }

    public bool CheckForJumpKeyPress()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            return true;
        }

        return false;
    }
}
