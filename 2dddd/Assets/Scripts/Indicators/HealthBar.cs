using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Slider _healthBar;
    [SerializeField] protected Health _health;

    protected virtual void Awake()
    {
        UpdateValue();
    }

    protected void OnEnable()
    {
        _health.AmountChanged += UpdateValue;
    }

    protected void OnDisable()
    {
        _health.AmountChanged -= UpdateValue;
    }

    protected virtual void UpdateValue()
    {
        _healthBar.value = _health.CurrentValue / _health.MaxValue;
    }
}
