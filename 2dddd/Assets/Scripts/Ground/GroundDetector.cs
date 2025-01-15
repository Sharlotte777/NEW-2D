using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private int _amountOfTouchingGround = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground _))
        {
            _amountOfTouchingGround++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground _))
        {
            _amountOfTouchingGround--;
        }
    }

    public bool IsGrounded()
    {
        return _amountOfTouchingGround > 0;
    }
}
