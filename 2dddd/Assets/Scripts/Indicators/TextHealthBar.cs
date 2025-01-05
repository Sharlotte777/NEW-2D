using UnityEngine;
using TMPro;

public class TextHealthBar : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [SerializeField] protected TMP_Text _text;

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
        if (_health.IsAlive)
            _text.SetText($"{_health.RealHealth} / {_health.MaxHealth}");
        else
            _text.SetText("Мертв");
    }
}
