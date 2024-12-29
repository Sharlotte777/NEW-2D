using UnityEngine;
using TMPro;

public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private FoxHealth _health;
    [SerializeField] private TMP_Text _text;

    private void Awake()
    {
        UpdateValue();
    }

    private void OnEnable()
    {
        _health.AmountChanged += UpdateValue;
    }

    private void OnDisable()
    {
        _health.AmountChanged -= UpdateValue;
    }

    private void UpdateValue()
    {
        if (_health.IsAlive)
            _text.SetText($"{_health.Health} / {_health.MaxHealth}");
        else
            _text.SetText("Мертв");
    }
}
