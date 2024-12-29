using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private FoxHealth _healthPlayer;

    private void Awake()
    {
        ChangeValue();
    }

    private void OnEnable()
    {
        _healthPlayer.AmountChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _healthPlayer.AmountChanged -= ChangeValue;
    }

    private void ChangeValue()
    {
        _healthBar.value = _healthPlayer.Health / _healthPlayer.MaxHealth;
    }
}
