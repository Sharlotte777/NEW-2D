using UnityEngine;
using TMPro;

public class TextHealthBar : MonoBehaviour
{
    [SerializeField] protected FoxHealth _health;
    [SerializeField] protected TMP_Text _text;

    protected virtual void Awake()
    {
        UpdateValue();
    }

    protected virtual void OnEnable()
    {
        _health.AmountChanged += UpdateValue;
    }

    protected virtual void OnDisable()
    {
        _health.AmountChanged -= UpdateValue;
    }

    protected virtual void UpdateValue()
    {
        if (_health.IsAlive)
            _text.SetText($"{_health.Health} / {_health.MaxHealth}");
        else
            _text.SetText("Мертв");
    }
}
