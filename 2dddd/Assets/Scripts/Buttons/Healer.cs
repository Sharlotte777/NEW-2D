using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Healer : MonoBehaviour
{
    [SerializeField] private FoxHealth _health;
    [SerializeField] private int _numberOfHeal = 10;

    private void OnEnable()
    {
        HealPlayer();
    }

    public void HealPlayer()
    {
        _health.HaveRecovered(_numberOfHeal);
    }
}
