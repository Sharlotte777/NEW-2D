using UnityEngine;
using TMPro;

public class TextHealthBar : HealthBar
{
    [SerializeField] protected TMP_Text _text;

    protected override void UpdateValue()
    {
        if (_health.IsAlive)
            _text.SetText($"{_health.RealHealth} / {_health.MaxHealth}");
        else
            _text.SetText("Мертв");
    }
}
