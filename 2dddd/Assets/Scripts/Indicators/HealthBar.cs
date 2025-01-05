using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : TextHealthBar
{
    [SerializeField] protected Slider _healthBar;

    protected override void UpdateValue()
    {
        _healthBar.value = _health.RealHealth / _health.MaxHealth;
    }
}
